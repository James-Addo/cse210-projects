public class Entry
{
    public string _date;
    public string _promptText;
    public string _entryText;
    public string _mood;
    public string _location;
    public string _weather;
    public int _timeSpent;

    public Entry(string date, string promptText, string entryText, string location, string mood, string weather, string timeSpent)
    {
        _date = date;
        _promptText = promptText;
        _entryText = entryText;
        _mood = mood;
        _location = location;
        _weather = weather;
        _timeSpent = int.Parse(timeSpent);
    }

    public void Display()
    {
        Console.WriteLine($"Date: {_date} - Prompt: {_promptText}");
        Console.WriteLine($"Prompt Response: {_entryText}");
        Console.WriteLine($"Mood: {_mood}");
        Console.WriteLine($"Location: {_location}");
        Console.WriteLine($"Weather: {_weather}");
        Console.WriteLine($"Time Spent: {_timeSpent} minutes");
        Console.WriteLine();
    }
}