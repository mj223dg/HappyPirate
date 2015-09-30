using HappyPirate.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HappyPirate.view
{
    class Console
    {
        public enum Menu { 
            None,
            AddMember
        }

        public void ShowMenu()
        {
            //System.Console.Clear();
            System.Console.WriteLine();
            System.Console.WriteLine("1. Add member");
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

            return Menu.None;
        }

        public void AddMember()
        {
            string firstName;
            string lastName;
            int socialSecurityNumber;

            

            System.Console.WriteLine("Add member");
            System.Console.Write("Enter first name: ");
            firstName = getUserInput();
            System.Console.Write("Enter last name: ");
            lastName = getUserInput();
            System.Console.Write("Enter social security number (numbers only): ");
            socialSecurityNumber = Int32.Parse(getUserInput());

            System.Console.WriteLine("You entered: ");
            System.Console.WriteLine("{0} {1}\n{2}", firstName, lastName, socialSecurityNumber);
            System.Console.WriteLine();
            System.Console.WriteLine("Save? (Y for yes, any other key for no)");

            char confirmSave = System.Console.ReadKey().KeyChar;
            
            if (confirmSave == 'y')
            {
                Member newMember = new Member(firstName, lastName, socialSecurityNumber);
                System.Console.WriteLine("Member saved!");
                System.Console.WriteLine("test");
            }

        }

    }
}
