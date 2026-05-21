// I have added code to load scriptures from a text file (scriptures.txt) and choose one at random to present to the user. 

using System;

class Program
{
    static void Main(string[] args)
    {
        List<Scripture> scriptureList = LoadScripturesFromFile("scriptures.txt");
        Scripture scriptureToMemorize = PickRandomScripture(scriptureList);
        RunMemorizationLoop(scriptureToMemorize);

        Console.Clear();
        Console.WriteLine(scriptureToMemorize.GetDisplayText());
    }

    static List<Scripture> LoadScripturesFromFile(string file)
    {
        List<Scripture> scriptures = new List<Scripture>();

        if (!File.Exists(file))
        {
            return scriptures;
        }

        string[] lines = File.ReadAllLines(file);

        foreach (string line in lines)
        {
            if (!line.Contains("|"))
            {
                continue;
            }

            string[] parts = line.Split('|');
            string referenceText = parts[0].Trim();
            string verseText = parts[1].Trim();

            Reference reference = ParseReference(referenceText);
            Scripture scripture = new Scripture(reference, verseText);
            scriptures.Add(scripture);
        }

        return scriptures;
    }

    static Scripture PickRandomScripture(List<Scripture> scriptures)
    {
        Random random = new Random();
        int index = random.Next(scriptures.Count);
        return scriptures[index];
    }

    static void RunMemorizationLoop(Scripture scripture)
    {
        while (!scripture.IsCompletelyHidden())
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nPress Enter to hide words, or type 'quit' to exit.");

            string userInput = Console.ReadLine();

            if (userInput != null && userInput.ToLower() == "quit")
            {
                break;
            }

            scripture.HideRandomWords(3);
        }
    }

    static Reference ParseReference(string referenceText)
    {
        string[] bookAndChapterVerse = referenceText.Split(' ', 2);
        string book = bookAndChapterVerse[0];

        string[] chapterAndVerse = bookAndChapterVerse[1].Split(':');
        int chapter = int.Parse(chapterAndVerse[0]);

        string versePart = chapterAndVerse[1];

        if (versePart.Contains('-'))
        {
            string[] verses = versePart.Split('-');
            int startVerse = int.Parse(verses[0]);
            int endVerse = int.Parse(verses[1]);
            return new Reference(book, chapter, startVerse, endVerse);
        }
        else
        {
            int verse = int.Parse(versePart);
            return new Reference(book, chapter, verse);
        }
    }
}