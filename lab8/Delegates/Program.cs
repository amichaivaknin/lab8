using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CustomersApp
{
    class Program
    {
        internal delegate bool CustomerFilter(Customer customer);

        //Didn't use IEnumerable and yield, nor ICollection
        static Collection<Customer> GetCustomers(Collection<Customer> customers, CustomerFilter customerFilter)
        {
            List<Customer> localCustomers = new List<Customer>();

            foreach (var customer in customers)
            {
                if (customerFilter(customer))
                {
                    localCustomers.Add(customer);
                }
            }
            return new Collection<Customer>(localCustomers);
        }

        public static bool CustomerFilterAK(Customer customer)
        {
            //What about 'a' and 'k'? 
            string name = customer.Name;
            return name[0] >= 'A' && name[0] <= 'K';
        }

        static void Main(string[] args)
        {
            List<Customer> customers = new List<Customer>();
            customers.Add(new Customer(1,"A","A"));
            customers.Add(new Customer(200, "K", "K"));
            customers.Add(new Customer(2, "B", "B"));
            customers.Add(new Customer(20, "Z", "Z"));
            customers.Add(new Customer(50, "L", "L"));
            customers.Add(new Customer(300, "Y", "Y"));

            CustomerFilter customerFilterAK = CustomerFilterAK;

            //If you used IEnumerable<Customer> or ICollection<Customer>, then you wouldn't have to use this System.Collections.ObjectModel.Collection. It is for other uses.
            Collection<Customer> customersAK = GetCustomers(new Collection<Customer>(customers), customerFilterAK);

            //Consider extracting this to another method
            foreach (var customer in customersAK)
            {
                Customer forCustomer = customer;

                //Why didn't you use ToStrin?
                Console.WriteLine("Id:"+forCustomer.ID+" Name:"+forCustomer.Name
                                   +" Address:"+ forCustomer.Address);
            }

            ////////anonymous delegate
            Console.WriteLine();
            CustomerFilter customerFilterLZ = delegate(Customer customer)
            {
                string name = customer.Name;
                return name[0] >= 'L' && name[0] <= 'Z';
            };

            Collection<Customer> customersLZ = GetCustomers(new Collection<Customer>(customers), customerFilterLZ);
            foreach (var customer in customersLZ)
            {
                Customer forCustomer = customer;
                Console.WriteLine("Id:" + forCustomer.ID + " Name:" + forCustomer.Name
                                   + " Address:" + forCustomer.Address);
            }
             
            /////////lambda expression
            Console.WriteLine();
            CustomerFilter customerFilterLess100 = (x) =>{return x.ID < 100;};
            Collection<Customer> customersLess100 = GetCustomers(new Collection<Customer>(customers), customerFilterLess100);
            foreach (var customer in customersLess100)
            {
                Customer forCustomer = customer;
                Console.WriteLine("Id:" + forCustomer.ID + " Name:" + forCustomer.Name
                                   + " Address:" + forCustomer.Address);
            }



        }


    }
}
