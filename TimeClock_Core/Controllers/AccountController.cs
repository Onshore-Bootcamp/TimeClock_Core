﻿namespace TimeClock_Core.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.Extensions.Configuration;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Text;
    using TimeClock_Core.Extensions;
    using TimeClock_Core.Filters;
    using TimeClock_Core.Mapping;
    using TimeClock_Core.Models;
    using TimeClock_Core.Models.LMS_Models;
    using TimeClock_Core_DAL;
    using TimeClock_Core_DAL.Models;

    public class AccountController : Controller
    {

        private readonly string apiKey;
        private readonly UserDAO userDataAccess;
        private readonly TimeEntryDAO timeEntryDAO;

        public AccountController(IConfiguration config)
        {
            apiKey = config.GetValue<string>("ApiKey", null);
            string connectionString = config.GetValue<string>("DataSource");
            userDataAccess = new UserDAO(connectionString);
            timeEntryDAO = new TimeEntryDAO(connectionString);
        }

        //User List
        //[SecurityFilter("/Home/Index", "Role", "Instructor")]
        public ActionResult Index()
        {
            List<User> allUsers = UserMapper.MapDoToList(userDataAccess.ViewUsers());
            return View(allUsers);
        }

        [HttpPost]
        public ActionResult Login(LoginForm form)
        {
            ActionResult oResponse = View("~/Views/Home/Index.cshtml", form);
            if (ModelState.IsValid)
            {
                UserDO userData = userDataAccess.ViewUserByUsername(form.Username);

                if (!userData.Id.Equals(default(int)))
                {
                    //User found.

                    //Test credentials.
                    if (userData.Role == "Instructor")
                    {
                        if (userData.Password == form.Password)
                        {
                            HttpContext.Session.Set("Username", Encoding.Unicode.GetBytes(form.Username));
                            HttpContext.Session.Set("Role", Encoding.Unicode.GetBytes("Instructor"));
                            //Session["Username"] = form.Username;
                            //Session["Role"] = "Instructor";
                            oResponse = RedirectToAction("Index", "Time");
                        }
                        else
                        {
                            ModelState.AddModelError("Password", "Username or password is incorrect");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("Password", "You're role is not allowed to login.");
                    }
                }
                else
                {
                    ModelState.AddModelError("Password", "Username or password is incorrect");
                }
            }
            return oResponse;
        }

        [HttpGet]
        public ActionResult Logout()
        {
            HttpContext.Session.Abandon();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        //[SecurityFilter("/Home/Index", "Role", "Instructor")]
        public ActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        //[SecurityFilter("/Home/Index", "Role", "Instructor")]
        public ActionResult CreateUser(User form)
        {
            ActionResult oResult = RedirectToAction("Index", "Account");
            if (ModelState.IsValid)
            {
                UserDO userObject = UserMapper.MapPoToSingle(form);
                userDataAccess.CreateUser(userObject);
            }
            else
            {
                oResult = View(form);
            }
            return oResult;
        }

        [HttpGet]
        public ActionResult ViewLMSGroups()
        {
            //Generate Group options from web request.

            WebClient client = new WebClient { Credentials = new NetworkCredential(apiKey, "") };

            string resp = client.DownloadString("https://onshore.talentlms.com/api/v1/groups");

            List<LMSGroup> groups = JsonConvert.DeserializeObject<List<LMSGroup>>(resp);

            ViewBag.Groups = new List<SelectListItem>();
            foreach (LMSGroup group in groups)
            {
                ViewBag.Groups.Add(new SelectListItem { Text = group.Name, Value = group.Id });
            }

            string response = client.DownloadString("https://onshore.talentlms.com/api/v1/courses");
            List<LMSCourse> courses = JsonConvert.DeserializeObject<List<LMSCourse>>(response);
            ViewBag.Courses = new List<SelectListItem>();
            foreach (LMSCourse course in courses)
            {
                ViewBag.Courses.Add(new SelectListItem { Text = course.Name, Value = course.Id.ToString() });
            }

            //Generate options from json response.
            return View();
        }

        [HttpGet]
        public ActionResult CreateUsersFromLMSGroup(long groupId, long courseId)
        {
            ActionResult oResponse;
            if (groupId == default(long) || courseId == default(long))
            {
                oResponse = RedirectToAction("ViewLMSGroups");
            }
            else
            {
                WebClient client = new WebClient { Credentials = new NetworkCredential(apiKey, "") };

                string resp = client.DownloadString("https://onshore.talentlms.com/api/v1/groups/id:" + groupId);

                LMSGroup group = JsonConvert.DeserializeObject<LMSGroup>(resp);

                ViewBag.GroupName = group.Name;

                ViewBag.Users = new List<LMSUserFull>();
                foreach (LMSUserSummarized user in group.users)
                {
                    WebClient userClient = new WebClient { Credentials = new NetworkCredential(apiKey, "") };
                    string userInfoResponse = userClient.DownloadString("https://onshore.talentlms.com/api/v1/users/id:" + user.id);
                    LMSUserFull userData = JsonConvert.DeserializeObject<LMSUserFull>(userInfoResponse);

                    userData.CourseId = courseId;
                    userData.GroupId = groupId;

                    ViewBag.Users.Add(userData);
                }
                oResponse = View();
            }
            return oResponse;
        }

        [HttpPost]
        public ActionResult CreateUsersFromLMS(List<LMSUserFull> users)
        {
            if (users != null)
            {
                foreach (LMSUserFull lmsUser in users)
                {
                    if (lmsUser.chosen)
                    {
                        int.TryParse(lmsUser.id, out int lmsId);
                        User user = new User
                        {
                            Username = lmsUser.login,
                            FirstName = lmsUser.first_name,
                            LastName = lmsUser.last_name,
                            Active = lmsUser.status == "active",
                            Password = "@onshore!",
                            LMSId = lmsId,
                            Role = lmsUser.user_type,
                            GroupId = lmsUser.GroupId,
                            CourseId = lmsUser.CourseId
                        };
                        userDataAccess.CreateUser(UserMapper.MapPoToSingle(user));
                    }
                }
            }
            return RedirectToAction("Index", "Account");
        }
        
        [AjaxOnly]
        public object GetUserTitle(string username)
        {
            if (username == null)
            {
                return Unauthorized();
            }

            string title = "User not found";
            User user = UserMapper.MapDoToSingle(userDataAccess.ViewUserByUsername(username));
            if (user.Id != 0)
            {
                title = user.Role;

                TimeEntry currentEntry = TimeEntryMapper.MapDoToSingle(timeEntryDAO.ViewCurrentEntry(user.Id, DateTime.Now));
                if (currentEntry.TimeIn != default(DateTime))
                {
                    title += " ";
                }
            }
            return title;
        }
    }
}