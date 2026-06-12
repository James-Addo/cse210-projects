using System;

public abstract class Goal
{
    protected int _points;
    protected string _shortName;
    protected string _description;

    public Goal(string name, string description, int points)
    {
        _shortName = name;
        _description = description;
        _points = points;
    }

    public int GetPoints()
    {
        return _points;
    }

    public abstract void RecordEvent();

    public abstract bool IsComplete();

    public virtual string GetDetailsString()
    {
        string status;

        if (IsComplete() == true)
        {
            status = "[X]";
        }
        else
        {
            status = "[ ]";
        }

        string result = $"{status} {_shortName} ({_description})";
        return result;
    }   
    public abstract string GetStringRepresentation();
}