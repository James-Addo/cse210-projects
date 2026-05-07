using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter your first name: ");
        string fristName = Console.ReadLine();

        Console.Write("Enter grade percentage: ");
        string userResponse = Console.ReadLine();
        int gradePercentage = int.Parse(userResponse);

        string letter = "";
        string letterSign = "";

        if (gradePercentage >= 90)
        {
            letter = "A";
        }

        else if (gradePercentage >= 80)
        {
            letter = "B";
        }

        else if (gradePercentage >= 70)
        {
            letter = "C";
        }

        else if (gradePercentage >= 60)
        {
            letter = "D";
        }

        else
        {
            letter = "F";
        }

        if ((gradePercentage % 10 > 3) && (gradePercentage % 10 < 7) || (gradePercentage >= 93) || (gradePercentage < 60))
        {
            letterSign = "";
        }

        else if (gradePercentage % 10 < 3)
        {
            letterSign = "-";
        }

        else if (gradePercentage % 10 >= 7)
        {
            letterSign = "+";
        }

        Console.WriteLine($"{fristName}, your grade is {letter}{letterSign}");

        if (gradePercentage >= 70)
        {
            Console.Write($"Congratulations, you passed the class!");
        }

        else
        {
            Console.WriteLine($"You did not pass this time, but keep working at it.");
        }
    }
}