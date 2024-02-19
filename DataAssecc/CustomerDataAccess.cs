using DataAccess.Models;
using System.Collections.ObjectModel;

namespace DataAccess
{
    public class CustomerDataAccess
    {
        public ObservableCollection<Customer> Customers { get; set; } = [];

        public CustomerDataAccess()
        {
            GetCustomers();
        }

        public void GetCustomers()
        {
            throw new NotImplementedException();
        }

        public void AddCustomer(Customer customer)
        {
            Customers.Add(customer);
        }

        public void EditCustomer(Customer customer)
        {
            var lastCustomer = Customers.FirstOrDefault(x => x.Id == customer.Id);
            int index = Customers.IndexOf(lastCustomer);
            Customers[index] = customer;
        }

        public void RemoveCustomer(int id)
        {
            var customer = Customers.FirstOrDefault(x => x.Id == id);
            Customers.Remove(customer);
        }

        public int GetNextId()
        {
            var maxIndex = Customers.Count != 0 ? Customers.Max(x => x.Id) + 1 : 1;
            return maxIndex;
        }
    }
}
