public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int target, int bonus)
        : base(name, description, points)
    {
        _amountCompleted = 0;
        _target = target;
        _bonus = bonus;
    }

    public override void RecordEvent()
    {
        _amountCompleted = _amountCompleted + 1;
    }

    public override bool IsComplete()
    {
        if (_amountCompleted >= _target)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public override string GetDetailsString()
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

        string result = $"{status} {_shortName} ({_description}) -- Currently completed: {_amountCompleted}/{_target}";
        return result;
    }
    public override string GetStringRepresentation()
    {
        return "ChecklistGoal:" + _shortName + "|" + _description + "|" + _points + "|" + _bonus + "|" + _target + "|" + _amountCompleted;
    }

    public int GetBonus()
    {
        return _bonus;
    }

    public int GetTarget()
    {
        return _target;
    }
}