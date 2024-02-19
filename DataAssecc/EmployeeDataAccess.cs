using DataAccess.ApplicatoionDbContext;
using DataAccess.Models;
using DataAccess.Utilities;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;

namespace DataAccess
{
    public class EmployeeDataAccess
    {
        public ObservableCollection<Employee> Employees { get; set; } = [];

        public EmployeeDataAccess()
        {
            GetEmployees();
        }

        public void GetEmployees()
        {
            using (ProductManagementDbContext dbContext = new())
            {
                dbContext.Employees.AsNoTracking().ToList().ForEach(x=>Employees.Add(x));
            };
            
        }
        
        public void AddEmployee(Employee employee)
        {
            using (ProductManagementDbContext dbContext = new())
            {
                dbContext.Employees.Add(employee);
                dbContext.SaveChanges();

                Employees.Add(dbContext.Employees.OrderBy(x => x.Id).Last());

            };
        }

        public void EditEmployee(Employee employee)
        {
            using (ProductManagementDbContext dbContext = new())
            {
                dbContext.Employees.Update(employee);
                dbContext.SaveChanges();

                GetEmployees();
            };
        }

        public void RemoveEmployee(int id)
        {
            using (ProductManagementDbContext dbContext = new())
            {
                var lastEmployee = dbContext.Employees.First(x => x.Id.Equals(id));
                dbContext.Employees.Remove(lastEmployee);
                dbContext.SaveChanges();

                GetEmployees();
            };
        }
    }
}
