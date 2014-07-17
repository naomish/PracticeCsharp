using System.Collections.Generic;

namespace AddressBookManager.DTOs
{
  public  class Contact
    {
     
      //maybe not on Volume prop?  thinking this prop is used to create a txt filepath if one does not already exist. 
      //This does not get written into the txt file as a column, but gets shunted into the txtfile with mathcing element in filepath 
      //OR if no file exists yet one is created with that name (with warning to user).  
      //Prop also gets populated on way out from the txt-filepath so that it can be changed by user to move to new file/addressbookVolume.

      public string FirstName { get; set; }
      public string LastName { get; set; }
      public List<Phone> Phones { get; set; }
      public List<Address> Addresses { get; set; }
      public List<Email> Emails { get; set; }
      public string NotesField { get; set; }
      public string VolumeName { get; set; }
     // public bool IsFavorite { get; set; } //don't think i need this.
      public int TimesSelected { get; set; } //can't decide if I want to flip a favorites bool above a certain number or add copy to a favorites list sorted by this number or just have linq return list of contacts where this property >x.

      public Contact()
      {
         Phones = new List<Phone>();
          Addresses = new List<Address>();
          Emails = new List<Email>();
      }
  }
}
