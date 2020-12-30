using System;
using System.Collections.Generic;
using System.Collections;

namespace MARKS_MANAGEMENT_SYSTEM
{
    class Program
    {
        static void Main(string[] args)
        {
            int yourChoice;
            bool checkInput = false;
            Dictionary<int, StudentMark> studentsList = new Dictionary<int, StudentMark>();
            
            while (true)
            {
                Menu();
                do
                {
                    Console.Write("\nOpition: ");
                    checkInput = int.TryParse(Console.ReadLine(), out yourChoice);
                } while (!checkInput || yourChoice <= 0 || yourChoice > 4);
                switch (yourChoice)
                {
                    case 1:
                        StudentMark newStudent = new StudentMark();
                        Console.Write("Please input student fullname: ");
                        newStudent.FullName = FormatName(Console.ReadLine());
                        Console.Write("Please input class name: ");
                        newStudent.Class = Console.ReadLine();
                        do
                        {
                            int studentSemester;
                            Console.Write("Please input semester: ");
                            checkInput = int.TryParse(Console.ReadLine(), out studentSemester);
                            newStudent.Semester = studentSemester;
                        } while (!checkInput || newStudent.Semester <= 0);
                        for (int i = 0; i < newStudent.SubjectMarkList.Capacity; i++)
                        {
                            int marks;
                            do
                            {
                                Console.Write($"Please input marks of subject {i + 1}: ");
                                checkInput = int.TryParse(Console.ReadLine(), out marks);
                            } while (!checkInput || marks < 0 || marks > 100);
                            newStudent.SubjectMarkList.Add(marks);
                        }
                        studentsList.Add(newStudent.Id, newStudent);
                        break;
                    case 2:
                        TableShowStudent();
                        foreach (StudentMark student in studentsList.Values)
                        {
                            Console.WriteLine(student.Display());
                        }
                        break;
                    case 3:
                        TableShowStudent();
                        foreach (StudentMark student in studentsList.Values)
                        {
                            student.AveCal();
                            Console.WriteLine(student.Display());
                        }
                        break;
                    case 4:
                        Environment.Exit(0);
                        break;
                }

            }
            
        }

        static void Menu()
        {
            Console.WriteLine("---------------------------");
            Console.WriteLine("MARKS MANAGEMENT SYSTEM\n");
            Console.WriteLine("Please select an opition\n");
            Console.WriteLine("1. Insert new Student");
            Console.WriteLine("2. View list of Students");
            Console.WriteLine("3. Average Mark");
            Console.WriteLine("4. Exit");
        }

        static void TableShowStudent()
        {
            Console.WriteLine($"ID\t|\tFull name\t\t\t|\tClass\t|\tSemester\t|\tAverage Mark");
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------");
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
