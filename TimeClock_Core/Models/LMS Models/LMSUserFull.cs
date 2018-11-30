namespace TimeClock_Core.Models.LMS_Models
{
    using System;

    public class LMSUserFull
    {
        public bool chosen { get; set; }

        public string id { get; set; }

        public string login { get; set; }

        public string first_name { get; set; }

        public string last_name { get; set; }

        public string user_type { get; set; }

        public string status { get; set; }

        public Int64 GroupId { get; set; }

        public Int64 CourseId { get; set; }
    }
}
