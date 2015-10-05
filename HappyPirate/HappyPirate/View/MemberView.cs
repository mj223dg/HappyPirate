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
            System.Console.WriteLine();
            System.Console.WriteLine("Member: ");
            System.Console.WriteLine("1. View member - NOT WORKING");
            System.Console.WriteLine("2. Change member");
            System.Console.WriteLine("3. Delete member");
            System.Console.WriteLine("Esc - go back");

            return int.Parse(System.Console.ReadKey().KeyChar.ToString());
        }

        public static void DeleteMember(string line)
        {
            System.Console.WriteLine("Are you sure you want to delete selected member? (y for yes)");

            char choice = System.Console.ReadKey().KeyChar;

            if (choice.ToString() == "y")
            {
                model.DAL.MemberDAL.DeleteMember(line);
            }
        }

        public void ChangeMember(Member member)
        {
            Member newMemberInfo = InputToMemberObject();

            member.FirstName = newMemberInfo.FirstName;
            member.LastName = newMemberInfo.LastName;
            member.SocialSecurityNumber = newMemberInfo.SocialSecurityNumber;

            string memberKeyword = member.UniqueId;

            System.Console.WriteLine("{0} {1}\n{2}", member.FirstName, member.LastName, member.SocialSecurityNumber);
            System.Console.WriteLine();
            System.Console.WriteLine("Save? (Y for yes, any other key for no)");

            char confirmSave = System.Console.ReadKey().KeyChar;

            if (confirmSave == 'y')
            {
                model.DAL.MemberDAL.ChangeMember(memberKeyword, member);

                System.Console.WriteLine("Member saved!");
                System.Console.ReadKey();
            }
        }

        public static void AddMember()
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
                model.DAL.MemberDAL.DALAddMember(newMember);

                System.Console.WriteLine("Member saved!");
                System.Console.ReadKey();
            }
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

    }
}
