using HappyPirate.model;
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
        private static readonly string MemberSavePath;
        private static readonly string BoatSavePath;

        static Console()
        {
            MemberSavePath = Path.Combine(AppDomain.CurrentDomain
                .GetData("APPBASE").ToString(), "members.txt");

            BoatSavePath = Path.Combine(AppDomain.CurrentDomain
                .GetData("APPBASE").ToString(), "boats.txt");
        }

        public enum Menu { 
            None,
            AddMember,
            ViewMembers,
            AddBoat
        }

        public void ShowMenu()
        {
            ClearMenu();
            System.Console.WriteLine("1. Add member");
            System.Console.WriteLine("2. View Members");
            System.Console.WriteLine("3. Add boat");
            System.Console.WriteLine();
        }

        public void ClearMenu() 
        {
            System.Console.Clear();
            ShowHeader();
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
            MemberView.AddMember(MemberSavePath);
        }

        public void ViewMembers()
        {
            int choiceInt;
            List<string> memberList = MemberListView.ShowAllMembers(MemberSavePath);
                        
            while (true)
            {
                string choice = System.Console.ReadLine();
                
                if (Int32.TryParse(choice, out choiceInt))
                {
                    break;
                }

                System.Console.WriteLine("Must choose a member");
            }

            System.Console.WriteLine(memberList[choiceInt - 1]);

            MemberView.ShowMemberMenu();

            string memberMenuChoice = System.Console.ReadKey().KeyChar.ToString();

            if (memberMenuChoice == "3")
            {
                DeleteMember(memberList[choiceInt - 1].ToString());
            }
            if (memberMenuChoice == "2")
            {
                ChangeMember(memberList[choiceInt - 1].ToString());
            }        

        }

        public void DeleteMember(string line)
        {
            MemberView.DeleteMember(line, MemberSavePath);
        }

        public void ChangeMember(string member)
        {
            MemberView.ChangeMember(member, MemberSavePath);
        }

        private Member InputToMemberObject() 
        {
            string firstName;
            string lastName;
            string socialSecurityNumber;

            while (true)
            {
                System.Console.Write("Enter first name: ");
                firstName = getUserInput();

                try
                {
                    if (Validation.validateString(firstName, 25))
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
                    if (Validation.validateString(lastName, 30))
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

            return new Member(firstName, lastName, socialSecurityNumber);
        }

        public void AddBoat()
        {
            System.Console.WriteLine("Add boat");

            Boat newBoat = InputToBoatObject();

            System.Console.WriteLine("You entered: ");
            System.Console.WriteLine("Boat type:{0}\nBoat length:{1}\nBoat width:{2}", newBoat.Type, newBoat.Width, newBoat.Length);
            System.Console.WriteLine();
            System.Console.WriteLine("Save? (Y for yes, any other key for no)");

            char confirmSave = System.Console.ReadKey().KeyChar;

            if (confirmSave == 'y')
            {

                using (StreamWriter writer = new StreamWriter(BoatSavePath, true))
                {
                    writer.WriteLine("{0} {1} {2}", newBoat.Type, newBoat.Length, newBoat.Width);
                }

                System.Console.WriteLine("Boat saved!");
                System.Console.ReadKey();
            }
        }

        private Boat InputToBoatObject()
        {
            string boatType;
            string width;
            int intWidth;
            string length;
            int intLength;
            string image;

            while (true)
            {
                System.Console.Write("Enter boat type: ");
                boatType = getUserInput();

                try
                {
                    if (Validation.validateString(boatType, 20))
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
                    if (Validation.validateBoatMeasures(width))
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
                    if (Validation.validateBoatMeasures(length))
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

            return new Boat(boatType, intWidth, intLength);
        }
    }
}
