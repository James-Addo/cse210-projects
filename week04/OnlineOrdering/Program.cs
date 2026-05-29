using System;

class Program
{
    static void Main(string[] args)
    {
        // Order 1 
        Address address1 = new Address("Daafi St", "Agona Swedru", "Central Region", "Ghana");
        Customer customer1 = new Customer("Emmanuel Ankomah", address1);

        List<Product> products1 = new List<Product>
        {
            new Product("Mobile Phone", "M102", 85, 2),
            new Product("Bluetooth Headphones", "T206", 31, 3)
        };

        Order order1 = new Order(customer1, products1);

        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order1.GetTotalCost()}");
        Console.WriteLine();


        // Order 2 
        Address address2 = new Address("12 Shibuya St", "Tokyo", "TKY", "Japan");
        Customer customer2 = new Customer("Aiko Tanaka", address2);

        List<Product> products2 = new List<Product>
        {
            new Product("Webcam", "W206", 43, 2),
            new Product("Mouse", "M801", 10, 1),
            new Product("Monitor", "T209", 20, 1)
        };

        Order order2 = new Order(customer2, products2);

        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total: ${order2.GetTotalCost()}");
        Console.WriteLine();


        // Order 3 
        Address address3 = new Address("732 Main St", "New York", "NY", "USA");
        Customer customer3 = new Customer("John Smith", address3);

        List<Product> products3 = new List<Product>
        {
            new Product("Gamepad", "G301", 55, 2),
            new Product("Projector", "P205", 200, 1)
        };

        Order order3 = new Order(customer3, products3);

        Console.WriteLine(order3.GetPackingLabel());
        Console.WriteLine(order3.GetShippingLabel());
        Console.WriteLine($"Total: ${order3.GetTotalCost()}");
        Console.WriteLine();


        // Order 4 
        Address address4 = new Address("742 Evergreen Terrace", "Springfield", "IL", "USA");
        Customer customer4 = new Customer("Emily Johnson", address4);

        List<Product> products4 = new List<Product>
        {
            new Product("Laptop", "L305", 250, 2),
            new Product("External Hard Drive", "H407", 25, 2)
        };

        Order order4 = new Order(customer4, products4);

        Console.WriteLine(order4.GetPackingLabel());
        Console.WriteLine(order4.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order4.GetTotalCost()}");
    }
}