using DataAccess.Models;
using System.Collections.ObjectModel;
using System.Diagnostics.Metrics;

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
            throw new NotImplementedException();
        }

        public void AddEmployee(Employee employee)
        {
            Employees.Add(employee);
        }

        public void EditEmployee(Employee employee)
        {
            var lastEmployee = Employees.FirstOrDefault(x => x.Id == employee.Id);
            int index = Employees.IndexOf(lastEmployee);
            Employees[index] = employee;
        }

        public void RemoveEmployee(int id)
        {
            var employee = Employees.FirstOrDefault(x => x.Id == id);
            Employees.Remove(employee);
        }

        public int GetNextId()
        {
            var maxIndex = Employees.Count != 0 ? Employees.Max(x => x.Id) + 1 : 1;
            return maxIndex;
        }
    }
}
