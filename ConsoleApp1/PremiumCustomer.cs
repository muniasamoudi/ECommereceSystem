using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal sealed class PremiumCustomer : Customer
    {
        public PremiumCustomer(int customid,string name,string city):base(customid, name,city) { }
    }
}
