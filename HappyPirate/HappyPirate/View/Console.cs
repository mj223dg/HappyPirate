using HappyPirate.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace HappyPirate.view
{
    class Console
    {
        public enum Menu { 
            None,
            AddMember,
            ViewMembers,
            AddBoat
        }

        public void ShowMenu()
        {
            System.Console.Clear();
            ShowHeader();
            System.Console.WriteLine("1. Add member");
            System.Console.WriteLine("2. View Members");
            System.Console.WriteLine("3. Add boat");
            System.Console.WriteLine();

            System.Console.WriteLine("     .  o ..                  ");
            System.Console.WriteLine("     o . o o.o                ");
            System.Console.WriteLine("          ...oo               ");
            System.Console.WriteLine("            __[]__            ");
            System.Console.WriteLine(@"         __|_o_o_o\__         ");
            System.Console.WriteLine("         \''''''''''/         ");
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
            System.Console.Write("Enter first name: ");
            firstName = getUserInput();
            System.Console.Write("Enter last name: ");
            lastName = getUserInput();
            System.Console.Write("Enter social security number (numbers only): ");
            socialSecurityNumber = getUserInput();

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

        public void AddBoat() 
        {
            string type;
            double width;
            double length;
            string image;

            System.Console.WriteLine("Add boat");

            System.Console.Write("Enter boat type: ");
            type = getUserInput();

            System.Console.Write("Enter width: ");
            width = Double.Parse(getUserInput());

            System.Console.Write("Enter length: ");
            length = Double.Parse(getUserInput());


            System.Console.WriteLine("You entered: ");
            System.Console.WriteLine("{0} {1}\n{2}", type, width, length);
            System.Console.WriteLine();
            System.Console.WriteLine("Save? (Y for yes, any other key for no)");

            string SavePath = Path.Combine(AppDomain.CurrentDomain
                                            .GetData("APPBASE").ToString(), "boats.txt");


            char confirmSave = System.Console.ReadKey().KeyChar;

            if (confirmSave == 'y')
            {
                Boat newBoat = new Boat(type, width, length);

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
