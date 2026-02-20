namespace OPPTimeClass.Backend;

public class Time
{
    //Fields
    private int _hour;
    private int _minute;
    private int _second;
    private int _millisecond;

    //Contrsuctors
    public Time()
    {
        _hour = 00;
        _minute = 00;
        _second = 00;
        _millisecond = 000;
    }

    public Time(int hour)
    {
        Hour = hour;
    }

    public Time(int hour, int minute)
    {
        Hour = hour;
        Minute = minute;
    }

    public Time(int hour, int minute, int second)
    {
        Hour = hour;
        Minute = minute;
        Second = second;
    }

    public Time(int hour, int minute, int second, int millisecond)
    {
        Hour = hour;
        Minute = minute;
        Second = second;
        Millisecond = millisecond;
    }

    //Properties
    public int Hour
    {
        get => _hour;
        set => _hour = ValidHour(value);
    }

    public int Minute
    {
        get => _minute;
        set => _minute = ValidMinute(value);
    }

    public int Second
    {
        get => _second;
        set => _second = ValidSecond(value);
    }

    public int Millisecond
    {
        get => _millisecond;
        set => _millisecond = ValidMillisecond(value);
    }

    //Methods
    public override string ToString()
    {
        var dt = new DateTime(2000, 1, 1, Hour, Minute, Second, Millisecond);
        return dt.ToString("hh:mm:ss.fff tt").ToUpper();
    }

    public int ToMilliseconds()
    {
        return (Hour * 3600000) + (Minute * 60000) + (Second * 1000) + Millisecond;
    }

    public int ToSeconds()
    {
        return (Hour * 3600) + (Minute * 60) + Second;
    }

    public int ToMinutes()
    {
        return (Hour * 60) + Minute;
    }

    public Time Add(Time other)
    {
        int ms = Millisecond + other.Millisecond;
        int carryMs = ms / 1000;
        ms %= 1000;

        int sec = Second + other.Second + carryMs;
        int carrySec = sec / 60;
        sec %= 60;

        int min = Minute + other.Minute + carrySec;
        int carryMin = min / 60;
        min %= 60;

        int hr = (Hour + other.Hour + carryMin) % 24;

        return new Time(hr, min, sec, ms);
    }

    public bool IsOtherDay(Time other)
    {
        return (this.ToMilliseconds() + other.ToMilliseconds()) >= 86400000;
    }

    private static int ValidHour(int hour)
    {
        if (hour < 0 || hour > 23)
        {
            throw new Exception($"The hour: {hour}, is not valid.");
        }
        return hour;

    }

    private static int ValidMinute(int minute)
    {
        if (minute < 0 || minute > 59)
        {
            throw new Exception($"The minute: {minute}, is not valid.");
        }
        return minute;
    }

    private static int ValidSecond(int second) { 
        if (second < 0 || second > 59)
        {
            throw new Exception($"The second: {second}, is not valid.");
        }
        return second;
    }

    private static int ValidMillisecond(int millisecond) {
        if (millisecond < 0 || millisecond > 999)
        {
            throw new Exception($"The millisecond: {millisecond}, is not valid.");
        }
        return millisecond;
    }
}
