using System;

public  class Misc
{
    public double GetWageFactor()
    {
        var now = DateTime.Now;

        switch (now.DayOfWeek)
        {
            // Weekend pays more:
            case DayOfWeek.Saturday:
            case DayOfWeek.Sunday:
                return 1.5;
            // Regular wage
            default:
                return 1.0;
        }
    }

    public double GetWageFactor(IClock clock)
    {
        // The injection of clock makes this function unit-testable
        var now = clock.TimeNow();

        switch (now.DayOfWeek)
        {
            // Weekend pays more:
            case DayOfWeek.Saturday:
            case DayOfWeek.Sunday:
                return 1.5;
            // Regular wage
            default:
                return 1.0;
        }
    }

    public interface IClock
    {
        DateTime TimeNow();
    }

    public class SystemClock : IClock
    {
        public DateTime TimeNow() => DateTime.Now;
    }

    public class UtcClock : IClock
    {
        public DateTime TimeNow() => DateTime.UtcNow;
    }

    // For testing
    public class WeekendClock : IClock
    {
        public DateTime TimeNow() => new DateTime(2018, 10, 28);
    }
}