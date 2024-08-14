using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp1
{
    internal class Customer : Person
    {
        public int CustomerID { get; set; }
        public ShoppingCart ShoppingCart { get; set; }

        public Customer(int customerID,string Name,string City):base(Name,City)
        {
            CustomerID = customerID;
            ShoppingCart = new ShoppingCart();
        }

        public override string GetPersonInfo()
        {
            return base.GetPersonInfo() + ($"  CustomerID : {CustomerID}");
        }

////////// 
        public Order PlaceOrder(PaymentMethod paymentMethod) {
            Order order = new Order(this);
            order.CreatOrder(paymentMethod);
            return order;


        }


      
    }
}
