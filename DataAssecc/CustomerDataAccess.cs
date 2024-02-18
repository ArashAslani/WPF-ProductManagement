using DataAccess.Models;

namespace DataAccess
{
    public class CustomerDataAccess
    {
        public List<Customer> Customers { get; set; } = [];

        public CustomerDataAccess()
        {
            GetCustomers();
        }

        private void GetCustomers()
        {
            throw new NotImplementedException();
        }

        private void AddProduct(Customer customer)
        {
            Customers.Add(customer);
        }

        private void EditProduct(Customer customer)
        {
            var lastCustomer = Customers.FirstOrDefault(x => x.Id == customer.Id);
            int index = Customers.IndexOf(lastCustomer);
            Customers[index] = customer;
        }

        private void RemoveProduct(int id)
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
