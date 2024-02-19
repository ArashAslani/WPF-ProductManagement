using DataAccess;
using DataAccess.Models;
using System.Windows;

namespace Wpf_ProductManagement
{
    public partial class AddEditEmployee : Window
    {
        private readonly EmployeeDataAccess _employeeDataAccess;
        private Employee _employee;
        private readonly bool isEdit = false;
        public AddEditEmployee(EmployeeDataAccess employeeDataAccess)
        {
            InitializeComponent(); 
            _employeeDataAccess = employeeDataAccess;
        }
        public AddEditEmployee(EmployeeDataAccess employeeDataAccess, Employee employee)
        {
            InitializeComponent();
            _employeeDataAccess = employeeDataAccess;
            _employee = employee;
            isEdit = true;

            TBFistName.Text = _employee.FirstName;
            TBFistName.Text = _employee.LastName;
            TBAddress.Text = _employee.Address;
            TBPhoneNumber.Text = _employee.PhoneNumber.ToString();
            TBBaseSalery.Text = _employee.BaseSalery.ToString();
            CBDepartment.SelectedIndex = (int)_employee.Department;
        }

        private void BTNCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BTNOK_Click(object sender, RoutedEventArgs e)
        {
            if(isEdit)
            {
                Employee emp = new()
                {
                    Id = _employee.Id,
                    FirstName = TBFistName.Text,
                    LastName = TBFistName.Text,
                    Address = TBAddress.Text,
                    PhoneNumber = Convert.ToUInt64(TBPhoneNumber.Text),
                    BaseSalery = Convert.ToDecimal(TBBaseSalery.Text),
                    Department = (Department)CBDepartment.SelectedIndex,
                };
                _employeeDataAccess.EditEmployee(emp);
            }
            else
            {
                Employee emp = new()
                {
                    FirstName = TBFistName.Text,
                    LastName = TBFistName.Text,
                    Address = TBAddress.Text,
                    PhoneNumber = Convert.ToUInt64(TBPhoneNumber.Text),
                    BaseSalery = Convert.ToDecimal(TBBaseSalery.Text),
                    Department = (Department)CBDepartment.SelectedIndex,
                };
                _employeeDataAccess.AddEmployee(emp);
            }
            this.Close();
        }
    }
}
