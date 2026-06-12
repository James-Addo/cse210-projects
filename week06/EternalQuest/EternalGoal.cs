public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points)
        : base(name, description, points) { }

    public override void RecordEvent()
    {
        // Nothing to do, eternal goals never finish
    }

    public override bool IsComplete()
    {
        return false;
    }

    // Always show [ ] because it's never complete
    public override string GetDetailsString()
    {
        string status = "[ ]";
        // Using format string $"" 
        string result = $"{status} {_shortName} ({_description})";
        return result;
    }
    public override string GetStringRepresentation()
    {
        return "EternalGoal|" + _shortName + "|" + _description + "|" + _points;
    }
}