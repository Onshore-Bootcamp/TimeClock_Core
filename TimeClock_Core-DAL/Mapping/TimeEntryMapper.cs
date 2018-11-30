namespace TimeClock_Core_DAL.Mapping
{
    using System.Data.SqlClient;
    using TimeClock_Core_DAL.Models;

    public class TimeEntryMapper
    {
        public static TimeEntryDO MapReaderToSingle(SqlDataReader reader)
        {
            TimeEntryDO oResult = new TimeEntryDO();
            oResult.Id = reader.GetInt64(0);
            oResult.UserId = reader.GetInt64(1);
            oResult.TimeIn = reader.GetDateTime(2);
            if (!reader.IsDBNull(3))
            {
                oResult.TimeOut = reader.GetDateTime(3);
            }
            return oResult;
        }
    }
}
