using DataAccess.Models;
using System.Collections.ObjectModel;

namespace DataAccess
{
    public class ProductDataAccess
    {
        public ObservableCollection<Product> Products { get; set; } = [];

        public ProductDataAccess()
        {
            GetProducts();
        }

        public void GetProducts()
        {
            throw new NotImplementedException();
        }

        public void AddProduct(Product product)
        {
            Products.Add(product);
        }

        public void EditProduct(Product product)
        {
            var lastProduct = Products.FirstOrDefault(x => x.Id == product.Id);
            int index = Products.IndexOf(lastProduct);
            Products[index] = product;
        }

        public void RemoveProduct(int id)
        {
            var product = Products.FirstOrDefault(x=>x.Id == id);
            Products.Remove(product);
        }

        public int GetNextId()
        {
            var maxIndex = Products.Count != 0 ? Products.Max(x => x.Id) + 1 : 1;
            return maxIndex;
        }
    }
}
