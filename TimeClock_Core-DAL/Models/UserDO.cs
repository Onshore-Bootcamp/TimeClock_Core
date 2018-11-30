namespace TimeClock_Core_DAL.Models
{
    public class UserDO
    {
        public long Id { get; set; }

        public long LMSId { get; set; }

        public long GroupId { get; set; }

        public long CourseId { get; set; }

        public string Username { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Password { get; set; }

        public string Role { get; set; }

        public bool Active { get; set; }
    }
}
