using System;
using System.Collections.Generic;   

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Group> groupContext = new List<Group>();
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("| MENU | 1 - Add Group | 2 - Add Student | 3 - Add Student Mark | 4 - View Student List | 5 - Find Student | 6 - Delete Group | EXIT |");
                Console.ResetColor();

                string userResponse = Console.ReadLine();

                if (userResponse.ToLower() == "exit")
                {
                    break;
                }
                
                int selection;
                bool selectionIsValid = int.TryParse(userResponse, out selection);

                if (selectionIsValid && selection >= 1 && selection <= 6)
                {
                    switch (selection)
                    {
                        case (int)AppMenuSelection.AddGroup:
                            Console.Write("Enter group's student count: ");
                            int studCount = Convert.ToInt32((Console.ReadLine());
                           

                            Console.Write("Enter group's name: ");
                            string grName = Console.ReadLine();
                            if (string.IsNullOrEmpty(grName))
                            {
                                Console.WriteLine("Group name is invalid!");
                                break;
                            }

                            Group newGroup = new Group(grName, studCount);

                            if (groupContext.Contains(newGroup))
                            {
                                Console.WriteLine("Group already exists.");
                                break;
                            }

                            groupContext.Add(newGroup);
                            Console.WriteLine("Group added successfully.");

                            break;

                        case (int)AppMenuSelection.AddStudent:
                            if (groupContext.Count <= 0)
                            {
                                Console.WriteLine("Add a group first.");
                                break;
                            }

                            Console.Write("Enter student's name: ");
                            string studName = Console.ReadLine();
                            if (string.IsNullOrEmpty(studName))
                            {
                                Console.WriteLine("Student's name is invalid.");
                                break;
                            }
                            
                            Console.Write("Enter student's surname: ");
                            string studSurname = Console.ReadLine();
                            if (string.IsNullOrEmpty(studSurname))
                            {
                                Console.WriteLine("Student's surname is invalid.");
                                break;
                            }

                            Console.Write("Enter student's major: ");
                            string studMajor = Console.ReadLine();
                            if (string.IsNullOrEmpty(studMajor))
                            {
                                Console.WriteLine("Student's major is invalid.");
                                break;
                            }
                            
                            Console.Write("Enter student's age: ");
                            string studAge = Console.ReadLine();
                            if (string.IsNullOrEmpty(studAge))
                            {
                                Console.WriteLine("Student's age is invalid.");
                                break;
                            }
                            break;

                        case (int)AppMenuSelection.ViewStudentList:
                            foreach (Group item in groupContext)
                            {
                                item.PrintAllStudents();
                            }
                            break;
                        case (int)AppMenuSelection.FindStudent:
                            Console.Write("Enter query: ");
                            string usersQuery = Console.ReadLine();
                            if (string.IsNullOrEmpty(usersQuery))
                            {
                                Console.WriteLine("Query invalid.");
                                break;
                            }

                            foreach (Group item in groupContext)
                            {
                                item.SearchAndPrintStudents(usersQuery);
                            }

                            break;
                        case (int)AppMenuSelection.DeleteGroup:

                            foreach (Group item in groupContext)
                            {
                                Console.WriteLine(item);
                            }

                            Console.Write("Enter the ID of the group that you want to delete: ");
                            int deleteGroupId;
                            bool deleteGroupIdIsValid = int.TryParse(Console.ReadLine(), out deleteGroupId);
                            if (!deleteGroupIdIsValid)
                            {
                                Console.WriteLine("Group ID is invalid.");
                                break;
                            }

                            Group groupToDelete = null;

                            foreach (Group item in groupContext)
                            {
                                if (item.Id == deleteGroupId)
                                {
                                    groupToDelete = item;
                                }
                            }

                            if (groupToDelete == null)
                            {
                                Console.WriteLine("Group does not exist.");
                                break;
                            }

                            groupContext.Remove(groupToDelete);

                            Console.WriteLine("Group deleted successfully.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid menu selection.");
                }
            }
            }
        }
    }
}
