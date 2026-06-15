using System;

public class Swimming : Activity
{
    private int _swimmingLaps;


    public Swimming(DateTime date, int minutes, int laps)
        : base(date, minutes)
    {
        _swimmingLaps = laps;
    }

    public override string GetActivityName()
    {
        return "Swimming";
    }

    public override double GetDistance()
    {
        return _swimmingLaps * 50 / 1000;
    }

    public override double GetSpeed()
    {
        return (GetDistance() / _lengthInMinutes) * 60;
    }

    public override double GetPace()
    {
        return _lengthInMinutes / GetDistance();
    }
}