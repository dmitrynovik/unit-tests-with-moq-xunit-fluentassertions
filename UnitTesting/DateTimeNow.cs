using System;

namespace Testing
{
    public class DateTimeNow
    {
    public int GetPrizeMoney()
	{
		var dt = DateTime.Now;
		return (dt.DayOfWeek == DayOfWeek.Sunday) ?
			1000000 : 0;
	}

    }
}
