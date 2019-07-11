using System;
using System.Globalization;
using ex_fixacao.Entities;
using ex_fixacao.Entities.Enums;

namespace ex_fixacao
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter cliente data:");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Birth date (DD/MM/YYYY): ");
            DateTime date = DateTime.Parse(Console.ReadLine());

            //instaciando objetos
            Client client = new Client(name, email, date);

            Console.WriteLine("Enter order data:");
            Console.Write("Status: (Pending_Payment, Processing, Shipped, Delivered) ");
            OrderStatus orderStatus = Enum.Parse<OrderStatus>(Console.ReadLine());
            Console.Write("How many items to this order?");
            int n = int.Parse(Console.ReadLine());

            Order order = new Order(DateTime.Now, orderStatus, client);

            for (int i = 1; i<=n; i++)
            {
                Console.WriteLine($"Enter #{i} item data:");
                Console.Write("Product name: ");
                string productName = Console.ReadLine();
                Console.Write("Product price: ");
                double productPrice = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Product product = new Product(productName, productPrice);
                Console.Write("Quantity: ");
                int quantity = int.Parse(Console.ReadLine());
                OrderItem orderItem = new OrderItem(quantity, productPrice, product);
                order.AddItem(orderItem);
            }
            Console.WriteLine();  
            Console.WriteLine("----");
            Console.WriteLine(order);
        }
    }
}
