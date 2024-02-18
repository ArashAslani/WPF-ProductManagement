using DataAccess.Models;

namespace DataAccess
{
    public class EmployeeDataAccess
    {
        public List<Employee> Employees { get; set; } = [];

        public EmployeeDataAccess()
        {
            GetEmployees();
        }

        private void GetEmployees()
        {
            throw new NotImplementedException();
        }

        private void AddProduct(Employee employee)
        {
            Employees.Add(employee);
        }

        private void EditProduct(Employee employee)
        {
            var lastEmployee = Employees.FirstOrDefault(x => x.Id == employee.Id);
            int index = Employees.IndexOf(lastEmployee);
            Employees[index] = employee;
        }

        private void RemoveProduct(int id)
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
