namespace TimeClock_Core_DAL.Models
{
    using System;

    public class TimeEntryDO
    {
        public long Id { get; set; }

        public DateTime TimeIn { get; set; }

        public DateTime TimeOut { get; set; }

        public virtual long UserId { get; set; }
    }
}
