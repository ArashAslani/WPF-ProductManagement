using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Xml.Linq;
using DataAccess.Models.Base;

namespace DataAccess.Models
{
    public class Employee : IPerson
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public int Id { get ; set ; }
        [Required]
        [StringLength(50)]
        public string FirstName { get ; set ; }
        [Required]
        [StringLength(50)]
        public string LastName { get ; set ; }
        public ulong PhoneNumber { get ; set ; }
        [Required]
        [StringLength(200)]
        public string Address { get ; set ; }
        public Department Department { get; set; }
        public decimal BaseSalery { get; set; }


        public string GetBasicInfo()
        {
            var info =
                FirstName + " " + LastName +
                "\nPhoneNumber : " + PhoneNumber +
                "\nAddress : " + Address +
                "\nDepartment : " + Department +
                "\nBase Salery : " + BaseSalery; ;
            return info;
        }
    }
}
