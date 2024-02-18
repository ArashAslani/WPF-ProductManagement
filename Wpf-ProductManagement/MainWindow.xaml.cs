using System.Windows;
using DataAccess;
using DataAccess.Models;

namespace Wpf_ProductManagement
{
    public partial class MainWindow : Window
    {


        public MainWindow()
        {
            InitializeComponent();
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

    }
}