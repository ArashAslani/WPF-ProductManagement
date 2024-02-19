using DataAccess;
using DataAccess.Models;
using System.Windows;

namespace Wpf_ProductManagement
{
    /// <summary>
    /// Interaction logic for AddEditProduct.xaml
    /// </summary>
    public partial class AddEditProduct : Window
    {
        private readonly ProductDataAccess _productDataAccess;
        private Product _product;
        private bool isEdit = false;

        public AddEditProduct(ProductDataAccess productDataAccess)
        {
            InitializeComponent();
            _productDataAccess = productDataAccess;
        }

        public AddEditProduct(ProductDataAccess productDataAccess, Product product)
        {
            InitializeComponent();
            _productDataAccess = productDataAccess;
            _product = product;
            isEdit = true;

            TBName.Text = product.Name;
            TBAuthor.Text = product.Name;
            TBPrice.Text = product.Price.ToString();
            TBCountAvailable.Text = product.AvailableCount.ToString();
        }

        private void BTNCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BTNOk_Click(object sender, RoutedEventArgs e)
        {
            if(isEdit)
            {
                Product product = new()
                {
                    Id = _product.Id,
                    Name = TBName.Text,
                    Author = TBAuthor.Text,
                    Price = Convert.ToDecimal(TBPrice.Text),
                    AvailableCount = Convert.ToInt32(TBCountAvailable.Text)
                };
                _productDataAccess.EditProduct(product);
            }
            else
            {
                Product product = new()
                {
                    Id = _product.Id,
                    Name = TBName.Text,
                    Author = TBAuthor.Text,
                    Price = Convert.ToDecimal(TBPrice.Text),
                    AvailableCount = Convert.ToInt32(TBCountAvailable.Text)
                };
                _productDataAccess.AddProduct(product);
            }
        }
    }
}
