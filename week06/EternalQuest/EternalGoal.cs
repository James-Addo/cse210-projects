public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points)
        : base(name, description, points) { }

    public override void RecordEvent()
    {
    }

    public override bool IsComplete()
    {
        return false;
    }

    public override string GetDetailsString()
    {
        string status = "[ ]";
        string result = $"{status} {_shortName} ({_description})";
        return result;
    }
    public override string GetStringRepresentation()
    {
        return "EternalGoal:" + _shortName + "|" + _description + "|" + _points;
    }
}