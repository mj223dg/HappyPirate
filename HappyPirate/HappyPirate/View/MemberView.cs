using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HappyPirate.model;
using System.IO;
using HappyPirate.Shared;

namespace HappyPirate.view
{
    class MemberView
    {
        public Member GetMember(int textFileLineIndex)
        {
            return model.DAL.MemberDAL.GetMember(textFileLineIndex);
        }

        public int ShowMemberMenu()
        {
            string selectedNumber;
            int selectedNumberInt;

            while (true)
            {
                System.Console.WriteLine();
                System.Console.WriteLine("Member: ");
                System.Console.WriteLine("1. View member");
                System.Console.WriteLine("2. Change member");
                System.Console.WriteLine("3. Delete member");
                System.Console.WriteLine(" - - - - - - - - ");
                System.Console.WriteLine("4. Add boat");
                System.Console.WriteLine("5. View member boats (change and delete)");
                System.Console.WriteLine("Any other key - go back");
                try
                {
                    selectedNumber = System.Console.ReadKey().KeyChar.ToString();
                    if (Int32.TryParse(selectedNumber, out selectedNumberInt) && selectedNumberInt <= 5 && selectedNumberInt >= 0)
                    {
                        return selectedNumberInt;
                    }
                    else
                    {
                        return 0;
                    }
                }
                catch (Exception)
                {
                    
                    throw;
                }
            }
        }

        public bool DoDeleteMember()
        {
            System.Console.WriteLine("Are you sure you want to delete selected member? (y for yes)");

            char choice = System.Console.ReadKey().KeyChar;

            if (choice.ToString() == "y")
            {
                return true;
            }
            return false;
        }

        public Member ChangeMember(Member member)
        {
            Member newMemberInfo = InputToMemberObject();

            member.FirstName = newMemberInfo.FirstName;
            member.LastName = newMemberInfo.LastName;
            member.SocialSecurityNumber = newMemberInfo.SocialSecurityNumber;

            //string memberKeyword = member.UniqueId;

            System.Console.WriteLine("{0} {1}\n{2}", member.FirstName, member.LastName, member.SocialSecurityNumber);
            System.Console.WriteLine();
            System.Console.WriteLine("Save? (Y for yes, any other key for no)");

            char confirmSave = System.Console.ReadKey().KeyChar;

            if (confirmSave == 'y')
            {
                System.Console.WriteLine("Member saved!");
                System.Console.ReadKey();
                
                return member;
            }
            return null;
        }

        public Member AddMember()
        {
            System.Console.WriteLine("Add member");

            Member newMember = InputToMemberObject();

            System.Console.WriteLine("You entered: ");
            System.Console.WriteLine("{0} {1}\n{2}", newMember.FirstName, newMember.LastName, newMember.SocialSecurityNumber);
            System.Console.WriteLine();
            System.Console.WriteLine("Save? (Y for yes, any other key for no)");

            char confirmSave = System.Console.ReadKey().KeyChar;

            if (confirmSave == 'y')
            {
                //model.DAL.MemberDAL.AddMember(newMember);

                System.Console.WriteLine("Member saved!");

                return newMember;
            }

            return null;

        }

        private static Member InputToMemberObject()
        {
            string firstName;
            string lastName;
            string socialSecurityNumber;

            while (true)
            {
                System.Console.Write("Enter first name: ");
                firstName = System.Console.ReadLine();

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
                lastName = System.Console.ReadLine();

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
                socialSecurityNumber = System.Console.ReadLine();

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


        public void ShowSpecificMemberInfo(Member member, List<Boat> memberBoats)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("Name: {0} {1}", member.FirstName, member.LastName);
            Console.WriteLine("Social Security Number: {0}", member.SocialSecurityNumber);
            Console.WriteLine("Member ID: {0}", member.UniqueId);
            Console.WriteLine("Boats: ");

            foreach (var boat in memberBoats)
            {
                if (boat.OwnerId == member.UniqueId)
                {
                    Console.WriteLine(" - - - Type: {0}, size: {1}*{2} meters", boat.Type, boat.Width, boat.Length);
                }
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to go back.");
            Console.ReadKey();
        }
    }
}
