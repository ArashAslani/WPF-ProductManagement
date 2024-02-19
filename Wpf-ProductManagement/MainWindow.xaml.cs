using System.Collections.ObjectModel;
using System.Windows;
using DataAccess;
using DataAccess.Models;

namespace Wpf_ProductManagement
{
    public partial class MainWindow : Window
    {
        readonly EmployeeDataAccess employeeDataAccess = new();
        readonly CustomerDataAccess customerDataAccess = new();
        readonly ProductDataAccess productDataAccess = new();

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

            EmployeesDataGrid.ItemsSource = Employees;
            CustomersDataGrid.ItemsSource = Customers;
            ProductsDataGrid.ItemsSource = Products;
        }

        private void FillData()
        {
            Employees = employeeDataAccess.Employees;
            Products = productDataAccess.Products;
            Customers = customerDataAccess.Customers;
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
            AddEditEmployee addEditEmployee = new(employeeDataAccess);
            addEditEmployee.ShowDialog();
        }

        private void BtnEditEmployee_Click(object sender, RoutedEventArgs e)
        {
            if (EmployeesDataGrid.SelectedIndex > 0)
            {
                CurrentEmployee = (Employee)EmployeesDataGrid.SelectedItem;
                AddEditEmployee addEditEmployee = new(employeeDataAccess, CurrentEmployee);
                addEditEmployee.ShowDialog();
            }
        }

        private void BtnRemoveEmployee_Click(object sender, RoutedEventArgs e)
        {
            if(EmployeesDataGrid.SelectedIndex > 0)
            {
                CurrentEmployee = (Employee)EmployeesDataGrid.SelectedItem;
                employeeDataAccess.RemoveEmployee(CurrentEmployee.Id);
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

        }

        private void BtnEditCustomer_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnRemoveCustomer_Click(object sender, RoutedEventArgs e)
        {

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

        }

        private void BtnEditProduct_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnRemoveProduct_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}