using DataAccess.Models;

namespace DataAccess
{
    public class ProductDataAccess
    {
        public List<Product> Products { get; set; } = [];

        public ProductDataAccess()
        {
            GetProducts();
        }

        private void GetProducts()
        {
            throw new NotImplementedException();
        }

        private void AddProduct(Product product)
        {
            Products.Add(product);
        }

        private void EditProduct(Product product)
        {
            var lastProduct = Products.FirstOrDefault(x => x.Id == product.Id);
            int index = Products.IndexOf(lastProduct);
            Products[index] = product;
        }

        private void RemoveProduct(int id)
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
