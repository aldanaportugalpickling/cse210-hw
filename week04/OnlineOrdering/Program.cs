using System;

class Program
{
    static void Main(string[] args)
    {
        Address a1 = new Address("123 Main St", "Los Angeles", "CA", "USA");
        Address a2 = new Address("456 Elm St", "Toronto", "Ontario", "Canada");

        Customer c1 = new Customer("Aldana Portugal", a1);
        Customer c2 = new Customer("Natividad Mori", a2);

        Product p1 = new Product("SmartWatch", 1001, 800, 2);
        Product p2 = new Product("Laptop", 1002, 1300, 1);
        Product p3 = new Product("Headphone", 1003, 100, 3);
        Product p4 = new Product("Mouse", 1004, 50, 4);

        Order o1 = new Order(c1);
        o1.AddProduct(p1);
        o1.AddProduct(p3);

        Order o2 = new Order(c2);
        o2.AddProduct(p2);
        o2.AddProduct(p4);

        Console.WriteLine("Order 1");
        Console.WriteLine(o1.PackingLabel());
        Console.WriteLine(o1.ShippingLabel());
        Console.WriteLine($"Total Price: {o1.GetTotalCost()}");

        Console.WriteLine();
        Console.WriteLine();

        Console.WriteLine("Order 2");
        Console.WriteLine(o2.PackingLabel());
        Console.WriteLine(o2.ShippingLabel());
        Console.WriteLine($"Total Price: {o2.GetTotalCost()}");
    }
}