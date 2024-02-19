using System.Diagnostics;
using System.Xml.Linq;
using DataAccess.Models.Base;

namespace DataAccess.Models
{
    public class Employee : IPerson
    {
        public int Id { get ; set ; }
        public string FirstName { get ; set ; }
        public string LastName { get ; set ; }
        public ulong PhoneNumber { get ; set ; }
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
