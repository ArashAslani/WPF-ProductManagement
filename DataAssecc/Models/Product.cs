using DataAccess.Models.Base;

namespace DataAccess.Models
{
    public class Product : IProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }
        public int AvailableCount { get; set; }

        public string GetBasicInfo()
        {
            var info =
                Name + 
                "\nAuthor : " + Author + 
                "\nPrice : " + Price + 
                "\nAvailableCount : " + AvailableCount;
            return info;
        }
    }
}
