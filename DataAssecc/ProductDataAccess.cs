using DataAccess.ApplicatoionDbContext;
using DataAccess.Models;
using DataAccess.Utilities;
using Microsoft.EntityFrameworkCore;
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
            using (ProductManagementDbContext dbContext = new())
            {
                Products = dbContext.Products.AsNoTracking().ToList().ToObservableCollection<Product>();
            };
        }

        public void AddProduct(Product product)
        {
            using (ProductManagementDbContext dbContext = new())
            {
                dbContext.Products.Add(product);
                dbContext.SaveChanges();
            };
        }

        public void EditProduct(Product product)
        {
            using (ProductManagementDbContext dbContext = new())
            {
                var lastProduct = dbContext.Products.First(x => x.Id == product.Id);
                dbContext.Products.Update(lastProduct);
                dbContext.SaveChanges();
            };
        }

        public void RemoveProduct(int id)
        {
            using (ProductManagementDbContext dbContext = new())
            {
                var lastProduct = dbContext.Products.First(x => x.Id == id);
                dbContext.Products.Remove(lastProduct);
                dbContext.SaveChanges();
            };
        }
    }
}
