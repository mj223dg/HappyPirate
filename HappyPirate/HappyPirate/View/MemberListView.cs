using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HappyPirate.view
{
    class MemberListView
    {
        public void ShowAllMembers(string MemberSavePath)
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
        }
    }
}
