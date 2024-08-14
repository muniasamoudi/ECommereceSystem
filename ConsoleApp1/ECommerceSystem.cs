using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class ECommerceSystem
    {
        static void Main(string[] args)
        {
            var customer1 = new Customer(1,"Munia","Jenin");
            var paymentMethod = new CreditCardPayment();
            

            var product1 = new Product(1, "T-shirt", 150.0, 2);
            var product2 = new Product(2, "jeans", 100.0, 1);
            var product3 = new Product(3, "shoose", 200.0, 2);

            customer1.ShoppingCart.addProduct(product1);
            customer1.ShoppingCart.addProduct(product2);
            customer1.ShoppingCart.addProduct(product3);

            Order order = customer1.PlaceOrder(paymentMethod);

            order.SaveOrderToFile("order.json");
            Order loadedOrder = Order.LoadOrderFromFile("order.json");

            double totalamounts = customer1.ShoppingCart.totalQuantity();
            paymentMethod.PaymentProcess(totalamounts);

            Console.WriteLine($"Customer : {customer1.GetPersonInfo()}");
            foreach(var item in order.productList)
                Console.WriteLine(item.GetProductInfo());

        
            double totalwithdiscount = order.applyDiscounts(totalamounts, 0.5);

            Console.WriteLine($"Total Amount : {totalamounts}");
            Console.WriteLine($"Total Amount after discount (5%) is : {totalwithdiscount}");

            Console.ReadLine();

        }
    }
}
