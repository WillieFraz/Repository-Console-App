
public class AddressBookRepository
{
     private Dictionary<int, AddressBookContact> _contactsList = new Dictionary<int , AddressBookContact>();

    // Create
    public bool CreateContact(int id)
    {
        AddressBookContact contact = GetContactById(id);
        
        // Checking to make sure that Id doesn't already exist.
        if (contact != null)
        {
            return false;
        }
        
        contact = new AddressBookContact();
        if (contact != null)
        {
            _contactsList.Add(id, contact);
            return true;
        }

        return false;
    }

    // Read

    public int CountofAllContacts()
    {
        int currentCountofContacts = _contactsList.Count();
        return currentCountofContacts;
    }
    public void ListAllContacts()
    {
        foreach (KeyValuePair<int, AddressBookContact> contact in _contactsList)
        {
            Console.WriteLine($"Contact Id and Name: {contact.Key}, {contact.Value.Name}");
        }
    }
    

    public AddressBookContact GetContactByName(string name)
    {
        foreach (KeyValuePair<int, AddressBookContact> contact in _contactsList)
        {
            if(String.Equals(contact.Value.Name, name, StringComparison.OrdinalIgnoreCase))
            {
                return contact.Value;
            }
        }
        
        return null;
    }

    public AddressBookContact GetContactById(int id)
    {
        foreach (KeyValuePair<int, AddressBookContact> contact in _contactsList)
        {
            if(contact.Key == id)
            {
                return contact.Value;
            }
        }
        
        return null;
    }

    //Update
    public bool EditNameById(int id, string name)
    {
        return EditContactById(id, name, -1, null, null);
    }

    public bool EditAddressById(int id, string address)
    {
        return EditContactById(id, null, -1, null, address);
    }

    public bool EditEmailById(int id, string email)
    {
        return EditContactById(id, null, -1, email, null);
    }

    public bool EditPhoneNumberById(int id, int phoneNumber)    
    {
        return EditContactById(id, null, phoneNumber, null, null);
    }

    public bool EditContactById(int id, string name, int phoneNumber, string email, string address)
    {
        AddressBookContact contact = GetContactById(id);

        if (contact == null)
        {
            Console.WriteLine("Already to existing id.");
            return false;
        }

        if (name != null && name.Length > 0)
        {
            contact.Name = name;  
        }

        if (email != null && email.Length > 0)        
        {
            contact.Email = email;
        }

        if (address != null && address.Length > 0)
        {
            contact.Address = address;
        }

        if (phoneNumber >= 0 && phoneNumber.ToString().Length == 10)
        {
            contact.PhoneNumber = phoneNumber;
        }

        return true;
    }

    //Delete
    public bool RemoveContactById(int id)
    {
        AddressBookContact targetContact = GetContactById(id);
        
        if (targetContact == null)
        {
            return false;
        }

        bool deleteResult = _contactsList.Remove(id);
        return deleteResult;
    }
}

