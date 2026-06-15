using System;

public abstract class Activity
{
    protected DateTime _date;
    protected int _lengthInMinutes;

    public Activity(DateTime date, int minutes)
    {
        _date = date;
        _lengthInMinutes = minutes;
    }

    public abstract string GetActivityName();
    public abstract double GetDistance();  
    public abstract double GetSpeed();     
    public abstract double GetPace();      

    public string GetSummary()
    {
        string dateText = _date.ToString("dd MMM yyyy"); 
        string activityName = GetActivityName(); 

        return $"{dateText} {activityName} ({_lengthInMinutes} min): " +
               $"Distance {GetDistance():0.0} km, " +
               $"Speed {GetSpeed():0.0} kph, " +
               $"Pace {GetPace():0.00} min per km";
    }
}