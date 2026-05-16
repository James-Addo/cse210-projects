// I have added code to request additional information from the user to be saved in the Journal.
// Also included is code to handle the case where file doesn't exist when loading.
// Again, I have added code to handle the case where there are no entries to display when the user selects "Display".


using System;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();
        bool activeProgram = true;

        Console.WriteLine("Welcome to the Journal Program!\n");

        while (activeProgram)
        {
            Console.WriteLine("Please select one of the following choices: ");
            List<string> choices = new List<string> { "Write", "Display", "Load", "Save", "Quit" };

            for (int i = 0; i < choices.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {choices[i]}");
            }
            Console.Write("What would you like to do? ");

            string userChoice = Console.ReadLine();

            if (userChoice == "1")
            {
                string userPrompt = promptGenerator.GetRandomPrompt();
                Console.WriteLine(userPrompt);
                Console.Write("Your response: ");
                string userResponse = Console.ReadLine();

                Console.Write("How are you feeling? ");
                string userMood = Console.ReadLine();

                Console.Write("Where are you writing this entry from? ");
                string userLocation = Console.ReadLine();

                Console.Write("Weather: ");
                string weather = Console.ReadLine();

                Console.Write("Time spent writing (minutes): ");
                int userTimeSpent = int.Parse(Console.ReadLine());

                DateTime theCurrentTime = DateTime.Now;
                string dateText = theCurrentTime.ToShortDateString();
                Entry newEntry = new Entry(dateText, userPrompt, userResponse, userLocation, userMood, weather, userTimeSpent.ToString());

                journal.AddEntry(newEntry);
            }
            else if (userChoice == "2")
            {
                journal.DisplayAll();
            }
            else if (userChoice == "3")
            {
                Console.WriteLine("What is the filename to load from? ");
                string filename = Console.ReadLine();
                journal.LoadFromFile(filename);
            }
            else if (userChoice == "4")
            {
                Console.Write("What is the filename? ");
                string filename = Console.ReadLine();
                journal.SaveToFile(filename);
            }
            else if (userChoice == "5")
            {
                activeProgram = false;
                Console.WriteLine("Have a great day!");
            }
            else
            {
                Console.WriteLine("Invalid option. Try again.\n");
            }
        }
    }
}