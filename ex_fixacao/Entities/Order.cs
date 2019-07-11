using System;
using System.Globalization;
using System.Collections.Generic;
using System.Text;
using ex_fixacao.Entities.Enums;

namespace ex_fixacao.Entities
{
    class Order
    {
        public DateTime Moment { get; set; }
        public OrderStatus Status { get; set; }
        public Client Client { get; set; }
        public List<OrderItem> Items { get; set; }

        public Order()
        {
        }

        public Order(DateTime moment, OrderStatus status, Client client)
        {
            Moment = moment;
            Status = status;
            Client = client;
            Items = new List<OrderItem>();
        }

        public void AddItem(OrderItem item)
        {
            Items.Add(item);
        }

        public void RemoveItem(OrderItem item)
        {
            Items.Remove(item);
        }

        public double Total()
        {
            double sum = 0.0;
            foreach (OrderItem orderItem in Items)
            {
                sum += orderItem.SubTotal();
            }
            return sum;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("ORDER SUMMARY:");
            sb.AppendLine("Order moment: " + Moment.ToString("dd/MM/yyyy"));
            sb.AppendLine("Order status: " + Status);
            sb.AppendLine("Client: ");
            sb.AppendLine($"{Client.Name} ({Client.BirthDate}) - {Client.Email}");
            sb.AppendLine("Order items:");
            foreach(OrderItem item in Items)
            {
                sb.AppendLine(item.Product.Name + ", $" + item.Price.ToString("F2") + ", Quantity: " + item.Quantity + ", Subtotal: $" + item.SubTotal().ToString("F2"));
            }
            sb.Append("Total price: $" + Total().ToString("F2", CultureInfo.InvariantCulture));
            return sb.ToString();
        }

    }
}
