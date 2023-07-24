public class UserInterface{

    AddressBookRepository AddressRepo = new AddressBookRepository();

    bool keepRunning = true;
    public void DisplayMenu()
    {
        while (keepRunning == true)
        {
            Console.WriteLine("Option 1: List all Contacts ");
            Console.WriteLine("Option 2: Add a Contact");
            Console.WriteLine("Option 3: Edit Contact");
            Console.WriteLine("Option 4: Delete Contact");
            Console.WriteLine("Option 5: Quit");
            string choice = Console.ReadLine();
            Console.Clear();
            
            switch(choice)
            {
                case "1":
                    ListAllContacts();
                    break;
                case "2":
                    AddContact();
                    break;
                case "3":
                    EditContactById();
                    break;
                case "4":
                    DeleteContactById();
                    break;
                case "5":
                    keepRunning = false;
                    break;
                default:
                    Console.WriteLine("Invalid option please try again");
                    break;

            }

        }
    }
    
    void ListAllContacts()
    {
        int currentCount = AddressRepo.CountofAllContacts();
        if (currentCount == 0)
        {
            Console.WriteLine("List is empty");
        }
       AddressRepo.ListAllContacts();
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
            if (contact == null)
            {
                // in case id is null
                return;
            }
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
        if (contact == null)
        {
            // In case id is null
            return;
        }

        System.Console.WriteLine("Edit Options: ");
        System.Console.WriteLine($"Option 1) Name: {contact.Name}");
        System.Console.WriteLine($"Option 2) Phone Number: {contact.PhoneNumber}");
        System.Console.WriteLine($"Option 3) Email: {contact.Email}");
        System.Console.WriteLine($"Option 4) Address: {contact.Address}");
        string option = Console.ReadLine();

        switch (option)
        {
            case "1":
                Console.WriteLine("Enter new Name: ");
                string name = Console.ReadLine();
                AddressRepo.EditNameById(idNumber, name);
                break;
            case "2":
                Console.WriteLine("Enter a new Phone number: ");
                string phoneNumber = Console.ReadLine();
                AddressRepo.EditPhoneNumberById(idNumber, int.Parse(phoneNumber));
                break;
            case "3":
                Console.WriteLine("Enter a new email: ");
                string email = Console.ReadLine();
                AddressRepo.EditEmailById(idNumber, email);
                break;
            case "4":
                Console.WriteLine("Enter a new Address: ");
                string address = Console.ReadLine();
                AddressRepo.EditAddressById(idNumber, address);
                break;
            default:
                break;
        }
      }

        void DeleteContactById()
      {
        Console.WriteLine("What is the contact Id: ");
        string id = Console.ReadLine();
        int idNum = int.Parse(id);

        AddressBookContact delete = AddressRepo.GetContactById(idNum);
        if (delete == null)
        {
            return;
        }
        Console.WriteLine($"Contact deleted: {delete.Name}");
        AddressRepo.RemoveContactById(idNum);
        
      }
    
}