// I have added a level system where you level up every 100 points and the program shows "LEVEL UP! You are now at Level X!" to make it more fun.

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