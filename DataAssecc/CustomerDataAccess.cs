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
            Customers.Clear();
            using (ProductManagementDbContext dbContext = new())
            {
                dbContext.Customers.AsNoTracking().ToList().ForEach(x => Customers.Add(x));
            };
        }

        public void AddCustomer(Customer customer)
        {
            using (ProductManagementDbContext dbContext = new())
            {
                dbContext.Customers.Add(customer);
                dbContext.SaveChanges();

                Customers.Add(dbContext.Customers.OrderBy(x=>x.Id).Last());
            };

        }

        public void EditCustomer(Customer customer)
        {
            using (ProductManagementDbContext dbContext = new())
            {
                dbContext.Customers.Update(customer);
                dbContext.SaveChanges();

                GetCustomers();
            };
        }

        public void RemoveCustomer(int id)
        {
            using (ProductManagementDbContext dbContext = new())
            {
                var customer = dbContext.Customers.First(x => x.Id.Equals(id));
                dbContext.Customers.Remove(customer);
                dbContext.SaveChanges();

                GetCustomers();
            };
        }
    }
}
