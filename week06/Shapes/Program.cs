using System;

class Program
{
    static void Main(string[] args)
    {
        // Square square = new Square(5, "Red");
        // Console.WriteLine($"The area of the {square.GetColor()} square is {square.GetArea()}");

        // Rectangle rectangle = new Rectangle(9, 5, "Black");
        // Console.WriteLine($"The area of the {rectangle.GetColor()} rectangle is {rectangle.GetArea()}");

        // Circle circle = new Circle(6, "Blue");
        // Console.WriteLine($"The area of the {circle.GetColor()} circle is {circle.GetArea()}");

        List<Shape> shapes = new List<Shape>();
        shapes.Add(new Square(6, "Red"));
        shapes.Add(new Rectangle(7, 4, "Violet"));
        shapes.Add(new Circle(4, "Yellow"));

        foreach (Shape shape in shapes)
        {
            string color = shape.GetColor();
            double area = shape.GetArea();
            Console.WriteLine($"The area of the {color} shape is {area}");
        }
    }
}