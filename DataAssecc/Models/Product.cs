using DataAccess.Models.Base;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Models
{
    public class Product : IProduct
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        [StringLength(100)]
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
