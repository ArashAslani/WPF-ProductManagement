using DataAccess.ApplicatoionDbContext;
using DataAccess.Models;
using DataAccess.Utilities;
using Microsoft.EntityFrameworkCore;
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
            using (ProductManagementDbContext dbContext = new())
            {
                Customers = dbContext.Customers.AsNoTracking().ToList().ToObservableCollection<Customer>();
            };
        }

        public void AddCustomer(Customer customer)
        {
            using (ProductManagementDbContext dbContext = new())
            {
                dbContext.Customers.Add(customer);
                dbContext.SaveChanges();
            };
        }

        public void EditCustomer(Customer customer)
        {
            using (ProductManagementDbContext dbContext = new())
            {
                var lastCustomer = dbContext.Customers.First(x => x.Id.Equals(customer.Id));
                dbContext.Customers.Update(lastCustomer);
                dbContext.SaveChanges();
            };
        }

        public void RemoveCustomer(int id)
        {
            using (ProductManagementDbContext dbContext = new())
            {
                var lastCustomer = dbContext.Customers.First(x => x.Id.Equals(id));
                dbContext.Customers.Remove(lastCustomer);
                dbContext.SaveChanges();
            };
        }
    }
}
