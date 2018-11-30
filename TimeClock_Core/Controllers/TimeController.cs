using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using TimeClock_Core.Filters;
using TimeClock_Core.Mapping;
using TimeClock_Core.Models;
using TimeClock_Core_DAL;

namespace TimeClock_Core.Controllers
{
    public class TimeController : Controller
    {
        private readonly TimeEntryDAO timeEntryDataAccess;
        private readonly UserDAO userDataAccess;
        public TimeController(IConfiguration config)
        {
            string connectionString = config.GetValue<string>("DataSource", null);

            timeEntryDataAccess = new TimeEntryDAO(connectionString);
            userDataAccess = new UserDAO(connectionString);
        }

        //[SecurityFilter("/Home/Index", "Role", "Instructor")]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        //[SecurityFilter("/Home/Index", "Role", "Instructor")]
        public ActionResult TimeEntries()
        {
            ViewBag.Bootcampers = UserMapper.MapDoToList(userDataAccess.ViewUsers());
            return View();
        }

        [HttpGet]
        [AjaxOnly]
        public ActionResult GetTime(Int64 userId)
        {
            ViewBag.Username = userDataAccess.ViewUserByUserId(userId).Username;
            List<IGrouping<int, TimeEntry>> usersTimes = TimeEntryMapper.MapDoToList(timeEntryDataAccess.ViewByUserId(userId)).GroupBy(x => x.Week).OrderBy(x => x.Key).ToList();

            //List<TimeEntry> usersTimes = new List<TimeEntry>();
            //Times.TryGetValue(username, out usersTimes);
            return PartialView("_UsersTimesTable", usersTimes);
        }
    }
}