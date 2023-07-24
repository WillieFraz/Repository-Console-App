public class UserInterface
{

    AddressBookRepository AddressRepo = new AddressBookRepository();

    bool keepRunning = true;
    public void DisplayMenu()
    {
        Console.WriteLine("Option 1: List all Contacts ");
        Console.WriteLine("Option 2: Add a Contact");
        Console.WriteLine("Option 3: Edit Contact");
        Console.WriteLine("Option 4: Delete Contact");
        string choice = Console.ReadLine();
        Console.Clear();
        
        switch(choice)
        {
            case "1":
                AddressRepo.ListAllContacts();
                break;
            case "2":
                AddContact();
                break;
            case "3":
                EditContactById();
                break;
            case "4":

                break;
            default:
                keepRunning = false;
                break;
        
        }
    }
    
    void AddContact()
    {
        Console.WriteLine("What is the contact Id:");
        string id = Console.ReadLine();


        Console.WriteLine("What is the contacts name:");
        string name = Console.ReadLine();

        Console.WriteLine("Phone number: ");
        string phoneNumber = Console.ReadLine();

        Console.WriteLine("Email: ");
        string email = Console.ReadLine();

        Console.WriteLine("Address: ");
        string address = Console.ReadLine();
        
        bool newContactWasCreated = AddressRepo.CreateContact(int.Parse(id));
        if (newContactWasCreated == true)
        {
            AddressBookContact contact = AddressRepo.GetContactById(int.Parse(id));
            contact.Name = name;
            contact.PhoneNumber = int.Parse(phoneNumber);
            contact.Email = email;
            contact.Address = address;
        }
    }

    

    void EditContactById()
    {
        Console.WriteLine("Input an Id: ");
        string idInput = Console.ReadLine();
        int idNumber = int.Parse(idInput);
        
        AddressBookContact contact = AddressRepo.GetContactById(idNumber);
        
        System.Console.WriteLine("Edit Options: ");
        System.Console.WriteLine($"Option 1) Name: {AddressRepo.}");
        System.Console.WriteLine($"Option 2) Phone Number: {contact.PhoneNumber}");
        System.Console.WriteLine($"Option 3) Email: {contact.Email}");
        System.Console.WriteLine($"Option 4) Address: {contact.Address}");
        string option = Console.ReadLine();

        switch (option)
        {
            case "1":
                AddressRepo.EditNameById(idInput, contacts.Name);
                break;
            case "2":
                AddressRepo.EditPhoneNumberById(idInput, phoneNumber);
                break;
            case "3":
                AddressRepo.EditEmailById(idInput, email);
                break;
            case "4":
                AddressRepo.EditAddressById(idInput, address);
                break;
            default:
                break;
        }
      }

      static void DeleteContactById()
      {
        Console.WriteLine("What is the contact Id: ");
        string id = Console.ReadLine();
        int idNum = int.Parse(id);

        AddressRepo.GetContactById(idNum);
        Console.WriteLine($"Contact deleted:");
        
        // Phone died imma call you back in one second.
        
      }
    

}