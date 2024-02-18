using DataAccess.Models.Base;

namespace DataAccess.Models
{
    public class Customer : IPerson
    {
        public int Id { get ; set ; }
        public string FirstName { get ; set ; }
        public string LastName { get ; set ; }
        public ulong PhoneNumber { get ; set ; }
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
