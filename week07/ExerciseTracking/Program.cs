using System;

class Program
{
    static void Main(string[] args)
    {
        List<Activity> exercisesList = new List<Activity>();

        DateTime today = DateTime.Now;

        exercisesList.Add(new Running(today, 35, 5.4));
        exercisesList.Add(new Cycling(today, 42, 26.0));
        exercisesList.Add(new Swimming(today, 30, 75));

        foreach (Activity exercise in exercisesList)
        {
            Console.WriteLine(exercise.GetSummary());
        }
    }
}