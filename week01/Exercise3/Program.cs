using System;

class Program
{
    static void Main(string[] args)
    {

        // Console.Write("What is the magic number? ");
        // int magicNumber = int.Parse(Console.ReadLine());

        string playAgain = "yes";

        while (playAgain.ToLower() == "yes")
        {
            Random randomGenerator = new Random();
            int magicNumber = randomGenerator.Next(1, 101);
            int guessNumber = 0;
            int guessCount = 0;

            while (guessNumber != magicNumber)
            {
                Console.Write("What is your guess? ");
                guessNumber = int.Parse(Console.ReadLine());
                guessCount++;

                if (guessNumber < magicNumber)
                {
                    Console.WriteLine("Higher");
                }

                else if (guessNumber > magicNumber)
                {
                    Console.WriteLine("Lower");
                }

                else
                {
                    Console.WriteLine();
                    Console.WriteLine("You guessed it!");
                    Console.WriteLine($"You guessed {guessCount} times");
                }
            }

            Console.Write("Do you want to play again? ");
            playAgain = Console.ReadLine();
            Console.WriteLine();
        }

        Console.WriteLine("Thanks for playing!");
    }
}
