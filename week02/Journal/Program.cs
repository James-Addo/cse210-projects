using System;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGen = new PromptGenerator();
        bool activeProgram = true;

        while (activeProgram)
        {
            List<string> actions = new List<string> { "Write", "Display", "Save", "Load", "Quit" };

            for (int i = 0; i < actions.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {actions[i]}");
            }
            Console.Write("Select an option: ");

            string choice = Console.ReadLine();

            if (choice == "1")
            {
                string prompt = promptGen.GetRandomPrompt();
                Console.WriteLine(prompt);
                Console.Write("> ");
                string response = Console.ReadLine();

                string date = DateTime.Now.ToShortDateString();
                Entry newEntry = new Entry(date, prompt, response);

                journal.AddEntry(newEntry);
            }
            else if (choice == "2")
            {
                journal.DisplayAll();
            }
            else if (choice == "3")
            {
                Console.Write("Enter filename to save to: ");
                string filename = Console.ReadLine();
                journal.SaveToFile(filename);
            }
            else if (choice == "4")
            {
                Console.Write("Enter filename to load from: ");
                string filename = Console.ReadLine();
                journal.LoadFromFile(filename);
            }
            else if (choice == "5")
            {
                activeProgram = false;
                Console.WriteLine("Goodbye!");
            }
            else
            {
                Console.WriteLine("Invalid option. Try again.\n");
            }
        }
    }
}