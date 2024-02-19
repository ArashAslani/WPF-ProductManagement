using System.Collections.ObjectModel;
using System.Windows;
using DataAccess;
using DataAccess.Models;

namespace Wpf_ProductManagement
{
    public partial class MainWindow : Window
    {
        readonly EmployeeDataAccess _employeeDataAccess = new();
        readonly CustomerDataAccess _customerDataAccess = new();
        readonly ProductDataAccess _productDataAccess = new();

        ObservableCollection<Employee> Employees = [];
        ObservableCollection<Customer> Customers = [];
        ObservableCollection<Product> Products = [];

        public Employee CurrentEmployee { get; set; } = new();
        public Customer CurrentCustomer { get; set; } =new();
        public Product CurrentProduct { get; set; } = new();

        public MainWindow()
        {
            InitializeComponent();
            FillData();
            FillDataGrids();

            
        }

        private void FillDataGrids()
        {
            EmployeesDataGrid.ItemsSource = Employees;
            CustomersDataGrid.ItemsSource = Customers;
            ProductsDataGrid.ItemsSource = Products;
        }

        private void FillData()
        {
            Employees = _employeeDataAccess.Employees;
            Products = _productDataAccess.Products;
            Customers = _customerDataAccess.Customers;
        }

        private void BtnHome_Click(object sender, RoutedEventArgs e)
        {
            HomePanel.Visibility = Visibility.Visible;
            EmployeesPanel.Visibility = Visibility.Collapsed;
            CustomersPanel.Visibility = Visibility.Collapsed;
            ProductsPanel.Visibility = Visibility.Collapsed;
        }

        private void BtnEmployees_Click(object sender, RoutedEventArgs e)
        {
            HomePanel.Visibility = Visibility.Collapsed;
            EmployeesPanel.Visibility = Visibility.Visible;
            CustomersPanel.Visibility = Visibility.Collapsed;
            ProductsPanel.Visibility = Visibility.Collapsed;
        }

        private void BtnCustomers_Click(object sender, RoutedEventArgs e)
        {
            HomePanel.Visibility = Visibility.Collapsed;
            EmployeesPanel.Visibility = Visibility.Collapsed;
            CustomersPanel.Visibility = Visibility.Visible;
            ProductsPanel.Visibility = Visibility.Collapsed;
        }

        private void BtnProducts_Click(object sender, RoutedEventArgs e)
        {
            HomePanel.Visibility = Visibility.Collapsed;
            EmployeesPanel.Visibility = Visibility.Collapsed;
            CustomersPanel.Visibility = Visibility.Collapsed;
            ProductsPanel.Visibility = Visibility.Visible;
        }

        private void EmployeeDataGrid_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if(EmployeesDataGrid.SelectedIndex >= 0)
            {
                CurrentEmployee = (Employee)EmployeesDataGrid.SelectedItem;
                EmployeeLable.Content = CurrentEmployee.GetBasicInfo();
            }
        }

        private void BtnAddEmployee_Click(object sender, RoutedEventArgs e)
        {
            AddEditEmployee addEditEmployee = new(_employeeDataAccess);
            addEditEmployee.ShowDialog();
        }

        private void BtnEditEmployee_Click(object sender, RoutedEventArgs e)
        {
            if (EmployeesDataGrid.SelectedIndex > 0)
            {
                CurrentEmployee = (Employee)EmployeesDataGrid.SelectedItem;
                AddEditEmployee addEditEmployee = new(_employeeDataAccess, CurrentEmployee);
                addEditEmployee.ShowDialog();
            }
        }

        private void BtnRemoveEmployee_Click(object sender, RoutedEventArgs e)
        {
            if(EmployeesDataGrid.SelectedIndex > 0)
            {
                CurrentEmployee = (Employee)EmployeesDataGrid.SelectedItem;
                _employeeDataAccess.RemoveEmployee(CurrentEmployee.Id);
                EmployeeLable.Content = "----";
            }
        }

        private void CustomersDataGrid_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (CustomersDataGrid.SelectedIndex >= 0)
            {
                CurrentCustomer = (Customer)CustomersDataGrid.SelectedItem;
                CustomerLable.Content = CurrentCustomer.GetBasicInfo();
            }
        }

        private void BtnAddCustomer_Click(object sender, RoutedEventArgs e)
        {
            AddEditCustomer addEditCustomer = new(_customerDataAccess);
            addEditCustomer.ShowDialog();
        }

        private void BtnEditCustomer_Click(object sender, RoutedEventArgs e)
        {
            if(CustomersDataGrid.SelectedIndex > 0)
            {
                CurrentCustomer = (Customer)CustomersDataGrid.SelectedItem;
                AddEditCustomer addEditCustomer = new(_customerDataAccess, CurrentCustomer);
                addEditCustomer.ShowDialog();
            }
        }

        private void BtnRemoveCustomer_Click(object sender, RoutedEventArgs e)
        {
            if(CustomersDataGrid.SelectedIndex >= 0)
            {
                CurrentCustomer = (Customer)CustomersDataGrid.SelectedItem;
                _customerDataAccess.RemoveCustomer(CurrentCustomer.Id);
                CustomerLable.Content = "----";
            }
        }


        private void ProductsDataGrid_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (ProductsDataGrid.SelectedIndex >= 0)
            {
                CurrentProduct = (Product)ProductsDataGrid.SelectedItem;
                ProductLable.Content = CurrentProduct.GetBasicInfo();
            }
        }

        private void BtnAddProduct_Click(object sender, RoutedEventArgs e)
        {
            AddEditProduct addEditProduct = new(_productDataAccess);
            addEditProduct.ShowDialog();
        }

        private void BtnEditProduct_Click(object sender, RoutedEventArgs e)
        {
            if (ProductsDataGrid.SelectedIndex > 0)
            {
                CurrentProduct = (Product)ProductsDataGrid.SelectedItem;
                AddEditProduct addEditProduct = new(_productDataAccess, CurrentProduct);
                addEditProduct.ShowDialog();
            }
        }

        private void BtnRemoveProduct_Click(object sender, RoutedEventArgs e)
        {
            if (ProductsDataGrid.SelectedIndex >= 0)
            {
                CurrentCustomer = (Customer)ProductsDataGrid.SelectedItem;
                _customerDataAccess.RemoveCustomer(CurrentCustomer.Id);
                CustomerLable.Content = "----";
            }
        }
    }
}