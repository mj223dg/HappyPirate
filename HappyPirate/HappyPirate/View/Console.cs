﻿using HappyPirate.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using HappyPirate.Shared;

namespace HappyPirate.view
{
    class Console
    {
        public enum Menu { 
            None,
            AddMember,
            ViewMembers,
            SearchMember,
            AddBoat
        }

        public void ShowMenu()
        {
            System.Console.Clear();
            ShowHeader();
            System.Console.WriteLine("1. Add member");
            System.Console.WriteLine("2. View Members");
            System.Console.WriteLine("3. Add boat");
            System.Console.WriteLine("4. Seach for member");
            System.Console.WriteLine();

            System.Console.WriteLine("     .  o ..                  ");
            System.Console.WriteLine("     o . o o.o                ");
            System.Console.WriteLine("          ...oo               ");
            System.Console.WriteLine("            __[]__            ");
            System.Console.WriteLine(@"         __|_o_o_o\__         ");
            System.Console.WriteLine("          \''''''''''/         ");
            System.Console.WriteLine(@"          \. ..  . /          ");
            System.Console.WriteLine("     ^^^^^^^^^^^^^^^^^^^^ ");

        }

        public void ClearMenu() 
        {
            System.Console.Clear();
            ShowHeader();
            Boat boat = new Boat("hej", 1, 1);
            boat.ShowBoatImage();
        }

        private string getUserInput() 
        {
            return System.Console.ReadLine();
        }

        public Menu GetMenuChoice()
        {
            char c = System.Console.ReadKey().KeyChar;

            if (c == '1')
            {
                return Menu.AddMember;
            }
            if (c == '2')
            {
                return Menu.ViewMembers;
            }
            if (c == '3')
            {
                return Menu.AddBoat;
            }
            if (c == '4')
            {
                return Menu.SearchMember;
            }
            return Menu.None;
        }

        public void ShowHeader()
        {
            System.Console.WriteLine("//////////////////////");
            System.Console.WriteLine("// THE HAPPY PIRATE //");
            System.Console.WriteLine("//     BOAT CLUB    //");
            System.Console.WriteLine("//////////////////////");
            System.Console.WriteLine();
        }

        public void AddMember()
        {
            string firstName;
            string lastName;
            string socialSecurityNumber;


            System.Console.WriteLine("Add member");

            while (true)
            {
                System.Console.Write("Enter first name: ");
                firstName = getUserInput();

                try 
	            {
                    if (Validation.validateFirstName(firstName))
                    {
                        break;
                    }

                    System.Console.WriteLine("Firstname must be between 1 and 25 characters long");
	            }
	            catch (Exception)
	            {
                    throw;
	            }
            }

            while (true)
            {
                System.Console.Write("Enter last name: ");
                lastName = getUserInput();

                try
                {
                    if (Validation.validateLastName(lastName))
                    {
                        break;
                    }

                    System.Console.WriteLine("Lastname must be max 30 characters long and can't be empty");
                }
                catch (Exception)
                {
                    
                    throw;
                }
            }

            while (true)
            {
                System.Console.Write("Enter social security number (numbers only): ");
                socialSecurityNumber = getUserInput();

                try
                {
                    if (Validation.validateSocialNumber(socialSecurityNumber))
                    {
                        break;
                    }

                    System.Console.WriteLine("Something wrong with social number");

                }
                catch (Exception)
                {
                    
                    throw;
                }
            }

            System.Console.WriteLine("You entered: ");
            System.Console.WriteLine("{0} {1}\n{2}", firstName, lastName, socialSecurityNumber);
            System.Console.WriteLine();
            System.Console.WriteLine("Save? (Y for yes, any other key for no)");

            string SavePath = Path.Combine(AppDomain.CurrentDomain
                                            .GetData("APPBASE").ToString(), "members.txt");


            char confirmSave = System.Console.ReadKey().KeyChar;
            
            if (confirmSave == 'y')
            {
                Member newMember = new Member(firstName, lastName, socialSecurityNumber);
                
                using (StreamWriter writer = new StreamWriter(SavePath, true))
                {
                    writer.WriteLine("{0} {1} {2}", newMember.FirstName, newMember.LastName, newMember.SocialSecurityNumber);
                }

                System.Console.WriteLine("Member saved!");
                System.Console.ReadKey();
            }

        }

        public void ViewMembers()
        {
            string text = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain
                                            .GetData("APPBASE").ToString(), "members.txt"));

            System.Console.WriteLine(text);

            System.Console.ReadKey();
        }


        public void SearchMember()
        {
            System.Console.Write("Enter user name: ");

            string enteredName = getUserInput();
            string line;

            // Read the file and display it line by line.
            System.IO.StreamReader file = new System.IO.StreamReader(Path.Combine(AppDomain.CurrentDomain
                                            .GetData("APPBASE").ToString(), "members.txt"));

            while ((line = file.ReadLine()) != null)
            {
                if (line.ToLower().Contains(enteredName.ToLower()))
                {
                    System.Console.WriteLine(line);
                }
            } 

            file.Close();

            System.Console.Write("Press any key");
            System.Console.ReadKey();
        }


        public void AddBoat() 
        {
            string boatType;
            string width;
            int intWidth;
            string length;
            int intLength;
            string image;

            System.Console.WriteLine("Add boat");

            while (true)
            {
                System.Console.Write("Enter boat type: ");
                boatType = getUserInput();

                try
                {
                    if (Validation.validateBoatType(boatType))
                    {
                        break;
                    }

                    System.Console.WriteLine("Something wrong with boat type");
                }
                catch (Exception)
                {
                    
                    throw;
                }
            }

            while (true)
            {
                System.Console.Write("Enter width: ");
                width = getUserInput();

                try
                {
                    if (Validation.validateBoatWidth(width))
                    {
                        intWidth = int.Parse(width);
                        break;
                    }

                    System.Console.WriteLine("Something wrong with boat width");

                }
                catch (Exception)
                {
                    
                    throw;
                }
            }

            while (true)
            {
                System.Console.Write("Enter length: ");
                length = getUserInput();

                try
                {
                    if (Validation.validateBoatLength(length))
                    {
                        intLength = int.Parse(length);
                        break;
                    }

                    System.Console.WriteLine("Something wrong with boat length");
                }
                catch (Exception)
                {
                    
                    throw;
                }
            }


            System.Console.WriteLine("You entered: ");
            System.Console.WriteLine("Boat type:{0}\nBoat length:{1}\nBoat width:{2}", boatType, width, length);
            System.Console.WriteLine();
            System.Console.WriteLine("Save? (Y for yes, any other key for no)");

            string SavePath = Path.Combine(AppDomain.CurrentDomain
                                            .GetData("APPBASE").ToString(), "boats.txt");


            char confirmSave = System.Console.ReadKey().KeyChar;

            if (confirmSave == 'y')
            {
                Boat newBoat = new Boat(boatType, intWidth, intLength);

                using (StreamWriter writer = new StreamWriter(SavePath, true))
                {
                    writer.WriteLine("{0} {1} {2}", newBoat.Type, newBoat.Length, newBoat.Width);
                }

                System.Console.WriteLine("Boat saved!");
                System.Console.ReadKey();
            }
        }

    }
}
