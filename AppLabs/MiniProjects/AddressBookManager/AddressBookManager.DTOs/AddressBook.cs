using System.Collections.Generic;

namespace AddressBookManager.DTOs
{
   public class AddressBook
    {
       public List<Contact> Contacts { get; set; }
       public string Filepath { get; set; }
    }
}
