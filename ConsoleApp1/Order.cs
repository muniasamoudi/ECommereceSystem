using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace ConsoleApp1
{

    internal class Order : IDiscountable
    {
        public Customer Customer { get; set; }
        public List<Product> productList { get; set; }
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public ShoppingCart ShoppingCart { get; set; }
        public enum orderStatus
        {

            Pending,
            Processing,
            Shipped,
            Delivered
        }
        public  orderStatus Orderstatus { get; set; }
     
        public Order(Customer customer) {
            Customer = customer;
            OrderDate = DateTime.Now;
            Orderstatus = orderStatus.Pending;
            productList = new List<Product>(customer.ShoppingCart.Products);

        }
      
        public void CreatOrder(PaymentMethod paymentMethod)
        {
            Orderstatus = orderStatus.Shipped;
            double Productsamount = Customer.ShoppingCart.totalQuantity();
            paymentMethod.PaymentProcess(Productsamount);
            //  Console.WriteLine($"{Orderstatus} {paymentMethod} {Productsamount}");

        }

        public double applyDiscounts(double Productsamount,double discount)
        {
            return Productsamount * discount;
        }
        //

        void IDiscountable.applyDiscounts(double Productsamount, double discount)
        {

            throw new NotImplementedException();

        }

        public void SaveOrderToFile(string filePath)
        {
            var jsonData = JsonSerializer.Serialize(this);
            File.WriteAllText(filePath, jsonData);
            Console.WriteLine($"Order saved to {filePath}");

          
            var readData = File.ReadAllText(filePath);

            Console.WriteLine("order.json contant:");
            Console.WriteLine(readData);
            Console.WriteLine("________");
        }

        // Static Method to Load Order from JSON File
        public static Order LoadOrderFromFile(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    var jsonData = File.ReadAllText(filePath);
                    return JsonSerializer.Deserialize<Order>(jsonData);
                }
            }
            catch
            {
                Console.WriteLine("Order file not found");
            }
            throw new FileNotFoundException("Order file not found.");

        }

    }
}
