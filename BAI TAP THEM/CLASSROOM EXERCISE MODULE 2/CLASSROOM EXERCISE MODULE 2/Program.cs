using System;
using System.Collections.Generic;
using System.Collections;

namespace CLASSROOM_EXERCISE_MODULE_2
{
    class Program
    {
        static void Main(string[] args)
        {
            bool checkInput = false;
            int yourChoice;
            string postTitle;
            string postContent;
            string postAuthor;
            Forum newForum = new Forum();
            while (true)
            {
                Menu();
                do
                {
                    Console.Write("Please select one option above: ");
                    checkInput = int.TryParse(Console.ReadLine(), out yourChoice);
                } while (!checkInput || yourChoice <= 0 || yourChoice > 7);
                switch (yourChoice)
                {
                    case 1:
                        do
                        {
                            Console.Write("Please input Title of post: ");
                            postTitle = Console.ReadLine().Trim();
                        } while (postTitle == "");
                        postTitle = FormatTitle(postTitle);
                        do
                        {
                            Console.Write("Please input Content of post: ");
                            postContent = Console.ReadLine().Trim();
                        } while (postContent == "");
                        do
                        {
                            Console.Write("Please input Author of post: ");
                            postAuthor = Console.ReadLine().Trim();
                        } while (postAuthor == "");
                        postAuthor = FormatName(postAuthor);
                        Post newPost = new Post(postTitle, postContent, postAuthor);
                        if (newForum.Add(newPost)) Console.WriteLine("New post has added successful");
                        else Console.WriteLine("Please check again your input");
                        break;
                    case 2:
                        int idToSearch;
                        string newContent;
                        do
                        {
                            Console.Write("Please enter id of post you want to update content: ");
                            checkInput = int.TryParse(Console.ReadLine(), out idToSearch);
                        } while (!checkInput || idToSearch <= 0);
                        
                        do
                        {
                            Console.Write("Please input new content: ");
                            newContent = Console.ReadLine().Trim();
                        } while (newContent == "");
                        if (newForum.UpdateContent(idToSearch, newContent))
                        {
                            Console.WriteLine($"Your new content has updated successful for post with ID: {idToSearch}");
                        }
                        else Console.WriteLine($"Cannot find the post with ID: {idToSearch} to update new content");
                        break;
                    case 3:
                        int idToRemove;
                        do
                        {
                            Console.Write("Please enter id of post you want to remove: ");
                            checkInput = int.TryParse(Console.ReadLine(), out idToRemove);
                        } while (!checkInput || idToRemove <= 0);
                        if (newForum.RemovePostFromId(idToRemove))
                        {
                            Console.WriteLine($"The post with ID: {idToRemove} has removed successful");
                        }
                        else Console.WriteLine($"Cannot find the post with ID: {idToRemove} to remove");
                        break;
                    case 4:
                        Console.WriteLine(newForum.ShowAllPosts());
                        break;
                    case 5:
                        string titleToSearch = "";
                        string authorToSearch = "";
                        string resultToPrint;
                        do
                        {
                            Console.Write("Please input author to search Post: ");
                            authorToSearch = Console.ReadLine().Trim();
                        } while (authorToSearch == "");
                        authorToSearch = FormatName(authorToSearch);
                        do
                        {
                            Console.Write("Please input title to search Post: ");
                            titleToSearch = Console.ReadLine().Trim();
                        } while (titleToSearch == "");
                        titleToSearch = FormatTitle(titleToSearch).ToLower();
                        resultToPrint = newForum.SearchPost(authorToSearch, titleToSearch);
                        if (resultToPrint != "")
                        {
                            Console.WriteLine(resultToPrint);
                        }
                        else Console.WriteLine($"Cannot find the posts with Author: {authorToSearch} and Title: {titleToSearch}");
                        break;
                    case 6:
                        int rateInput = 0;
                        int idToRate;
                        do
                        {
                            Console.Write("Please input id of post: ");
                            checkInput = int.TryParse(Console.ReadLine(), out idToRate);
                        } while (!checkInput || idToRate <= 0);
                        int indexPost = newForum.SearchPostWithId(idToRate);
                        if (indexPost != -1)
                        {
                            do
                            {
                                Console.Write($"Please input your rate for post with ID {idToRate}: ");
                                checkInput = int.TryParse(Console.ReadLine(), out rateInput);
                            } while (!checkInput || rateInput < 1 || rateInput > 5);
                            newForum.Posts[indexPost].AddRate(rateInput);
                        } else Console.WriteLine("Invalid Post");
                        break;
                    case 7:
                        Environment.Exit(0);
                        break;
                }
            }

        }

        static void Menu()
        {
            Console.WriteLine("---------------------------");
            Console.WriteLine("POSTS MANAGEMENT SYSTEM\n");
            Console.WriteLine("1. Create Post");
            Console.WriteLine("2. Update Post");
            Console.WriteLine("3. Remove Post");
            Console.WriteLine("4. Show Posts");
            Console.WriteLine("5. Search");
            Console.WriteLine("6. Rating");
            Console.WriteLine("7. Exit");
        }

        static string FormatName(string nameInput)
        {
            //Remove space;
            nameInput = nameInput.Trim();
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

        static string FormatTitle(string titleInput)
        {
            //Remove space;
            titleInput = titleInput.Trim();
            while (titleInput.IndexOf("  ") != -1)
            {
                titleInput = titleInput.Replace("  ", " ");
            }
            //make Upercase first Char first Word
            string[] nameSplitArray = titleInput.Split(" ");
            char[] stringSplitToChar = nameSplitArray[0].ToCharArray();
            stringSplitToChar[0] = Char.ToUpper(stringSplitToChar[0]);
            nameSplitArray[0] = new string(stringSplitToChar);
            titleInput = String.Join(" ", nameSplitArray);
            return titleInput;
        }

        
    }
}
