using System;
using System.Collections.Generic;
using System.Text;

namespace PHONEBOOK_MANAGEMENT_SYSTEM
{
    class PhoneBook : IPhoneBook
    {
        private SortedList<string, string> _myPhoneBook = new SortedList<string, string>();

        public SortedList<string, string> MyPhoneBook { get => _myPhoneBook; set => _myPhoneBook = value; }

        public int InsertPhone(string name, string phone)
        {
            if (IsExists(name))
            {
                _myPhoneBook[name] += $" : {phone}";
                return 1;
            } else if (!IsExists(name))
            {
                _myPhoneBook.Add(name, phone);
                return 0;
            } else return -1;
        }

        public bool RemovePhone(string name)
        {
            if (IsExists(name))
            {
                _myPhoneBook.Remove(name);
                return true;
            } else return false;
        }
        public bool UpdatePhone(string name, string newPhone)
        {
            _myPhoneBook[name] = newPhone;
            if (_myPhoneBook[name] == newPhone)
            {
                return true;
            } else return false;
        }

        public string SearchPhone(string name)
        {
            if (IsExists(name))
            {
                return $"Name: {name}\t\t\tPhone number: {_myPhoneBook[name]}";
            }
            else return $"{name} doesn't has in phonebook";
        }

        //public void Sort()
        //{
        //    _myPhoneBook.Sort
        //}

        private bool IsExists(string name)
        {
            if (_myPhoneBook.ContainsKey(name)) return true;
            else return false;
        }


    }
}
