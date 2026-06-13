// I have added a level system where the user level up every 100 points to make it more fun.

using System;

class Program
{
    static void Main(string[] args)
    {
        {
            GoalManager manager = new GoalManager();
            manager.Start();
        }
    }
}