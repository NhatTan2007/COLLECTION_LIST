using System;
using System.Collections.Generic;
using System.Text;

namespace PHONEBOOK_MANAGEMENT_SYSTEM
{
    interface IPhoneBook
    {
        public int InsertPhone(string name, string phone);
        public bool RemovePhone(string name);
        public bool UpdatePhone(string name, string newPhone);
        public string SearchPhone(string name);
        //public void Sort();
    }
}
