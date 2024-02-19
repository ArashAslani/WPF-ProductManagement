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
                Employees = dbContext.Employees.AsNoTracking().ToList().ToObservableCollection<Employee>();
            };
            
        }
        
        public void AddEmployee(Employee employee)
        {
            using (ProductManagementDbContext dbContext = new())
            {
                dbContext.Employees.Add(employee);
                dbContext.SaveChanges();
            };
        }

        public void EditEmployee(Employee employee)
        {
            using (ProductManagementDbContext dbContext = new())
            {
                var lastEmployee = dbContext.Employees.First(x=>x.Id.Equals(employee.Id));
                dbContext.Employees.Update(lastEmployee);
                dbContext.SaveChanges();
            };
        }

        public void RemoveEmployee(int id)
        {
            using (ProductManagementDbContext dbContext = new())
            {
                var lastEmployee = dbContext.Employees.First(x => x.Id.Equals(id));
                dbContext.Employees.Remove(lastEmployee);
                dbContext.SaveChanges();
            };
        }
    }
}
