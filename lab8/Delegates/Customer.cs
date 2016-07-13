using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomersApp
{
    public class Customer : IComparable<Customer>, IEquatable<Customer>
    {
        private IComparable<Customer> _comparableImplementation;
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Address { get; private set; }

        public Customer(int id, string name, string address)
        {
            ID = id;
            Name = name;
            Address = address;
        }

        public int CompareTo(Customer other)
        {
            return string.Compare(Name, other.Name, StringComparison.OrdinalIgnoreCase);
        }

        public bool Equals(Customer other)//not insensitive
        {
            if (other == null) return false;

            if(Name==other.Name && ID==other.ID)
                return true;
            else
                return false;    
        }
    }
}
