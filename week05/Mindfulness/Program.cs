// I have included code to Keep a log of how many times each activity was performed.
// I have also included code to shuffle the prompts and questions so they come in a random order each time.
// Also included is a class (Menu.cs) to handle the menu and interaction with the user.

using System;

class Program
{
    static void Main(string[] args)
    {
        Menu menu = new Menu();
        menu.Run();
    }
}