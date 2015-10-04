﻿using System;
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
            string path = Path.Combine(AppDomain.CurrentDomain
                .GetData("APPBASE").ToString(), "members.txt");

            Member member = new Member();
            string[] memberCrendentials = new string[3];

            //http://stackoverflow.com/a/1262985
            string lineNumber = File.ReadLines(path).Skip(textFileLineIndex).Take(1).First();

            memberCrendentials = lineNumber.Split(' ');

            member.FirstName = memberCrendentials[0];
            member.LastName = memberCrendentials[1];
            member.SocialSecurityNumber = memberCrendentials[2];
            member.UniqueId = memberCrendentials[3];

            return member;
        }

        public static void ShowMemberMenu()
        {
            System.Console.WriteLine();
            System.Console.WriteLine("Member: ");
            System.Console.WriteLine("1. View member - NOT WORKING");
            System.Console.WriteLine("2. Change member");
            System.Console.WriteLine("3. Delete member");
            System.Console.WriteLine("Esc - go back");
        }

        public static void DeleteMember(string line, string path)
        {
            System.Console.WriteLine("Are you sure you want to delete selected member? (y for yes)");

            char choice = System.Console.ReadKey().KeyChar;

            if (choice.ToString() == "y")
            {
                File.WriteAllLines(path,
                    File.ReadLines(path).Where(l => l != line).ToList());
            }
        }

        public static void ChangeMember(string member, string path)
        {
            List<string> lines = new List<string>(File.ReadAllLines(path));
            int lineIndex = lines.FindIndex(line => line.StartsWith(member));

            if (lineIndex != -1)
            {
                Member newMember = InputToMemberObject();

                System.Console.WriteLine("{0} {1}\n{2}", newMember.FirstName, newMember.LastName, newMember.SocialSecurityNumber);
                System.Console.WriteLine();
                System.Console.WriteLine("Save? (Y for yes, any other key for no)");

                char confirmSave = System.Console.ReadKey().KeyChar;

                if (confirmSave == 'y')
                {
                    lines[lineIndex] = newMember.FirstName + " " + newMember.LastName + " " + newMember.SocialSecurityNumber + " " + newMember.UniqueId;
                    File.WriteAllLines(path, lines);

                    System.Console.WriteLine("Member saved!");
                    System.Console.ReadKey();
                }

            }
        }

        public static void AddMember(string path)
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
                using (StreamWriter writer = new StreamWriter(path, true))
                {
                    writer.WriteLine("{0} {1} {2} {3}", newMember.FirstName, newMember.LastName, newMember.SocialSecurityNumber, newMember.UniqueId);
                }

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
