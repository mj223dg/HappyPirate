﻿using HappyPirate.model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace HappyPirate.view
{
    public enum MemberListMenu
    {
        Compact,
        Verbose,
        None
    }

    class MemberListView
    {
        private string MemberSavePath = Path.Combine(AppDomain.CurrentDomain
                .GetData("APPBASE").ToString(), "members.txt");

        public int SelectMember()
        {
            int i = 0;
            string SelectedNumber;
            int SelectedNumberInt;

            using (StreamReader r = new StreamReader(MemberSavePath))
            {
                while (r.ReadLine() != null) { i++; }
            }

            while (true)
            {
                System.Console.WriteLine();
                System.Console.Write("Select member number and press enter: ");
                SelectedNumber = System.Console.ReadLine();

                try
                {
                    if (Int32.TryParse(SelectedNumber, out SelectedNumberInt) && SelectedNumberInt > 0 && SelectedNumberInt <= i)
                    {
                        return SelectedNumberInt - 1;
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public MemberListMenu SelectListTypeMenu()
        {
            string select;
            int selectInt;

            while (true)
            {
                System.Console.WriteLine();
                Console.WriteLine("Choose list type. 1 for compact, 2 for verbose.");
                select = Console.ReadKey().KeyChar.ToString();

                try
                {
                    if (Int32.TryParse(select, out selectInt))
                    {
                        if (selectInt == 1)
                        {
                            return MemberListMenu.Compact;
                        }
                        else if (selectInt == 2)
                        {
                            return MemberListMenu.Verbose;
                        }
                        else
                        {
                            Console.WriteLine("Please enter 1 or 2.");
                        }
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }


        }

        public void ShowCompactList(List<Member> members)
        {
            int count = 1;
            int numberOfBoats = 0;
            foreach (var member in members)
            {
                if (member.Boats == null)
                {
                    numberOfBoats = 0;
                }
                else
                {
                    numberOfBoats = member.Boats.Count;
                }
                Console.WriteLine("{0}. {1} {2}, {3}. Boats: {4}", count, member.FirstName, member.LastName, member.SocialSecurityNumber, numberOfBoats);
                count++;
            }
        }

        public void ShowVerboseList(List<Member> members)
        {
            int count = 1;
            foreach (var member in members)
            {
                Console.WriteLine("{0}. {1} {2} - {3}, id: {4}. ", count, member.FirstName, member.LastName, member.SocialSecurityNumber, member.UniqueId);
                Console.WriteLine(" ---- Boats: ");
                if (member.Boats != null)
                {
                    foreach (var boat in member.Boats)
                    {
                        Console.WriteLine("      {0}, {1}x{2}m", boat.Type, boat.Width, boat.Length);
                    }
                }
                else
                {
                    Console.WriteLine("      No boats");
                }
                Console.WriteLine();
                count++;
            }
        }

    }
}
