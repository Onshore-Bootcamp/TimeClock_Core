namespace TimeClock_Core.Extensions
{
    using Microsoft.AspNetCore.Http;

    public static class SessionExtensions
    {
        public static void Abandon(this ISession session)
        {
            session.Clear();
        }
    }
}
