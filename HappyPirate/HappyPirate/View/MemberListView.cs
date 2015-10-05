using HappyPirate.model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace HappyPirate.view
{
    class MemberListView
    {
        private string MemberSavePath = Path.Combine(AppDomain.CurrentDomain
                .GetData("APPBASE").ToString(), "members.txt");

        public List<string> ShowAllMembers()
        {
            int counter = 1;
            string line;

            List<string> memberList = new List<string>(100);

            System.IO.StreamReader file = new System.IO.StreamReader(MemberSavePath);
            while ((line = file.ReadLine()) != null)
            {
                System.Console.WriteLine("{0}. {1}", counter, line);
                memberList.Add(line);
                counter++;
            }
            file.Close();

            return memberList;
        }

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
    }
}
