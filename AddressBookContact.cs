public class AddressBookContact
{
  
  public string Name;
  public string Email;
  public int PhoneNumber;
  public string Address;

    public AddressBookContact(string name, string email, int phoneNumber, string address)
    {
        Name = name;
        Email = email;
        PhoneNumber = phoneNumber;
        Address = address;
    }  

    public AddressBookContact()
    {

    }
}