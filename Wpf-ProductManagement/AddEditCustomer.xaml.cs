using DataAccess;
using DataAccess.Models;
using System.Windows;

namespace Wpf_ProductManagement
{

    public partial class AddEditCustomer : Window
    {
        private readonly CustomerDataAccess _customerDataAccess;
        private Customer _customer;
        private readonly bool IsEdit = false;

        public AddEditCustomer( CustomerDataAccess customerDataAccess)
        {
            InitializeComponent();
            _customerDataAccess = customerDataAccess;
        }

        public AddEditCustomer( CustomerDataAccess customerDataAccess, Customer customer)
        {
            InitializeComponent();
            _customerDataAccess = customerDataAccess;
            _customer = customer;
            IsEdit = true;

            TBFirstName.Text = customer.FirstName;
            TBLastName.Text = customer.LastName;
            TBPhoneNumber.Text = customer.PhoneNumber.ToString();
            TBAddress.Text = customer.Address;
        }

        private void BTNClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BTNOk_Click(object sender, RoutedEventArgs e)
        {
            if(IsEdit)
            {
                Customer customer = new()
                {
                    Id = _customer.Id,
                    FirstName = TBFirstName.Text,
                    LastName = TBLastName.Text,
                    Address = TBAddress.Text,
                    PhoneNumber = Convert.ToUInt64(TBPhoneNumber.Text),
                };
                _customerDataAccess.EditCustomer(customer);
            }
            else
            {
                Customer customer = new()
                {
                    FirstName = TBFirstName.Text,
                    LastName = TBLastName.Text,
                    Address = TBAddress.Text,
                    PhoneNumber = Convert.ToUInt64(TBPhoneNumber.Text),
                };
                _customerDataAccess.AddCustomer(customer);
            }

            this.Close();
        }
    }
}
