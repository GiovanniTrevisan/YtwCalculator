namespace IMTC.CodeTest.Core.Services
{

    // Class made with the context passed to follow a financial context flow
    public class TimeService : ITimeService
    {
        public DateTime UtcNow => DateTime.UtcNow;
    }
}
