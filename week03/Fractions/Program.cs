using System;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Main(string[] args)
    {
        Fraction f1 = new Fraction();
        Fraction f2 = new Fraction(6);
        Fraction f3 = new Fraction(6, 7);
        Fraction f4 = new Fraction(1, 2);


        string fractionString;
        fractionString = f1.GetFractionString();
        Console.WriteLine(fractionString);

        fractionString = f2.GetFractionString();
        Console.WriteLine(fractionString);

        fractionString = f3.GetFractionString();
        Console.WriteLine(fractionString);

        fractionString = f4.GetFractionString();
        Console.WriteLine(fractionString);


        double decimalValue;
        decimalValue = f1.GetDecimalValue();
        Console.WriteLine(decimalValue);

        decimalValue = f2.GetDecimalValue();
        Console.WriteLine(decimalValue);

        decimalValue = f3.GetDecimalValue();
        Console.WriteLine(decimalValue);

        decimalValue = f4.GetDecimalValue();
        Console.WriteLine(decimalValue);

        f1.SetTop(5);
        {
            Console.WriteLine(f1.GetTop());
        }

        f1.SetBottom(3);
        {
            Console.WriteLine(f1.GetBottom());
        }

        f2.SetTop(8);
        {
            Console.WriteLine(f2.GetTop());
        }

        f2.SetBottom(9);
        {
            Console.WriteLine(f2.GetBottom());
        }

        f3.SetTop(10);
        {
            Console.WriteLine(f3.GetTop());
        }

        f3.SetBottom(11);
        {
            Console.WriteLine(f3.GetBottom());
        }

    }
}