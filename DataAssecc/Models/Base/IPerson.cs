namespace DataAccess.Models.Base
{
    public interface IPerson
    {
        int Id { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        ulong PhoneNumber { get; set; }
        string Address { get; set; }

        string GetBasicInfo();
    }
}
