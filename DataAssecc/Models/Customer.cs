using DataAccess.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models
{
    public class Customer : IPerson
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

        public string GetBasicInfo()
        {
            var info =
                FirstName + " " + LastName +
                "\nPhoneNumber : " + PhoneNumber +
                "\nAddress : " + Address;
            return info;
        }
    }
}
