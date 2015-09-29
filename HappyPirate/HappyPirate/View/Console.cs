using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HappyPirate.View
{
    class Console
    {
        public void ShowInstructions()
        {
            Model.Member newMember = new Model.Member();

            string firstName;
            string lastName;
            int socialSecurityNumber;

            System.Console.WriteLine("Välkommen :))");
            
            System.Console.Write("Fyll i förnamn: ");
            firstName = getUserInput();

            System.Console.Write("Fyll i efternamn: ");
            lastName = getUserInput();

            System.Console.Write("Fyll i personnummer: ");
            socialSecurityNumber = Int32.Parse(getUserInput());

        }

        public void CreateMember()
        { 
                        
        }

        public string getUserInput() 
        {
            return System.Console.ReadLine();
        }

    }
}
