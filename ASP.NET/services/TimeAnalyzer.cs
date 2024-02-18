namespace ASP.NET.services
{
    public class TimeAnalyzer : interfaces.ITimeAnalyzer
    {
        public string GetTimeOfDay(DateTime dateTime)
        {
            int hour = dateTime.Hour;
            if (0 <= hour && hour < 6) 
            {
                return "Night";
            }
            if (6 <= hour && hour < 12)
            {
                return "Morning";
            }
            if (12 <= hour && hour < 18)
            {
                return "Day";
            }
            if (18 <= hour && hour < 24)
            {
                return "Evening";
            }
            throw new Exception("Invalid data");
        }

    }
}
