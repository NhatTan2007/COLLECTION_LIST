using System;

namespace PHONEBOOK_MANAGEMENT_SYSTEM
{
    class Program
    {
        static void Main(string[] args)
        {
            PhoneBook tanPhoneBook = new PhoneBook();
            int yourChoice;
            bool checkInput = false;
            string nameInput;
            string phoneNumberStringInput;
            int phoneNumberInput;
            while (true)
            {
                Menu();
                do
                {
                    Console.Write("Please choice 1 opition above: ");
                    checkInput = int.TryParse(Console.ReadLine(), out yourChoice);
                } while (!checkInput || yourChoice > 6 || yourChoice <= 0);
                switch (yourChoice)
                {
                    case 1:
                        Console.Write("Please enter the name: ");
                        nameInput = Console.ReadLine();
                        nameInput = FormatName(nameInput);
                        do
                        {
                            Console.Write("Please enter phone number: ");
                            phoneNumberStringInput = Console.ReadLine();
                            checkInput = int.TryParse(phoneNumberStringInput, out phoneNumberInput);
                        } while (!checkInput || phoneNumberInput <= 0);
                        phoneNumberStringInput = FormatName(phoneNumberStringInput);
                        int result = tanPhoneBook.InsertPhone(nameInput, phoneNumberStringInput);
                        if (result == 0) Console.WriteLine($"Add contact {nameInput} with phone number {phoneNumberStringInput} success");
                        else if (result == 1) Console.WriteLine($"Contact {nameInput} is exists, {nameInput} now has more phone number is {phoneNumberStringInput}");
                        else if (result == -1) Console.WriteLine("Please check again your name or phone number");
                        break;
                    case 2:
                        Console.Write("Please enter the name: ");
                        nameInput = Console.ReadLine();
                        nameInput = FormatName(nameInput);
                        if (tanPhoneBook.RemovePhone(nameInput)) Console.WriteLine($"{nameInput} removed from phone book success");
                        else Console.WriteLine($"Please check your name input, {nameInput} isn't exists");
                        break;
                    case 3:
                        Console.Write("Please enter the name: ");
                        nameInput = Console.ReadLine();
                        nameInput = FormatName(nameInput);
                        do
                        {
                            Console.Write("Please enter new phone number: ");
                            phoneNumberStringInput = Console.ReadLine();
                            checkInput = int.TryParse(phoneNumberStringInput, out phoneNumberInput);
                        } while (!checkInput || phoneNumberInput <= 0);
                        phoneNumberStringInput = FormatName(phoneNumberStringInput);
                        string oldPhone = tanPhoneBook.MyPhoneBook[nameInput];
                        if (tanPhoneBook.UpdatePhone(nameInput, phoneNumberStringInput)) Console.WriteLine($"{nameInput} has replace {oldPhone} with new one {phoneNumberStringInput}");
                        else Console.WriteLine("Please check again your name or new phone number");
                        break;
                    case 4:
                        Console.Write("Please enter the name: ");
                        nameInput = Console.ReadLine();
                        nameInput = FormatName(nameInput);
                        Console.WriteLine(tanPhoneBook.SearchPhone(nameInput));
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;
                }
            }
        }

        static void Menu()
        {
            Console.WriteLine("---------------------------");
            Console.WriteLine("PHONEBOOK MANAGEMENT SYSTEM\n");
            Console.WriteLine("1. Insert phone");
            Console.WriteLine("2. Remove phone");
            Console.WriteLine("3. Update phone");
            Console.WriteLine("4. Search phone");
            //Console.WriteLine("5. Sort");
            Console.WriteLine("5. Exit");
        }

        static string FormatName(string nameInput)
        {
            //Remove space;
            while (nameInput.IndexOf("  ") != -1)
            {
                nameInput = nameInput.Replace("  ", " ");
            }
            //make Upercase first char each word.
            nameInput = nameInput.ToLower();
            string[] nameSplitArray = nameInput.Split(" ");
            for (int i = 0; i < nameSplitArray.Length; i++)
            {
                char[] stringSplitToChar = nameSplitArray[i].ToCharArray();
                stringSplitToChar[0] = Char.ToUpper(stringSplitToChar[0]);
                nameSplitArray[i] = new string(stringSplitToChar);
            }
            nameInput = String.Join(" ", nameSplitArray);
            return nameInput;
        }
    }
}
