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
        public enum Menu { 
            None,
            AddMember,
            ViewMembers,
            AddBoat
        }

        #region fields and constructor
        private static readonly string MemberSavePath;
        private static readonly string BoatSavePath;

        static Console()
        {
            MemberSavePath = Path.Combine(AppDomain.CurrentDomain
                .GetData("APPBASE").ToString(), "members.txt");

            BoatSavePath = Path.Combine(AppDomain.CurrentDomain
                .GetData("APPBASE").ToString(), "boats.txt");
        }
        #endregion


        #region console menu interface methods
        public void ShowMenu()
        {
            ClearMenu();
            System.Console.WriteLine("1. Add member");
            System.Console.WriteLine("2. View Members");
            System.Console.WriteLine("3. Add boat");
            System.Console.WriteLine();
        }

        public void ShowHeader()
        {
            System.Console.WriteLine("//////////////////////");
            System.Console.WriteLine("// THE HAPPY PIRATE //");
            System.Console.WriteLine("//     BOAT CLUB    //");
            System.Console.WriteLine("//////////////////////");
            System.Console.WriteLine();
        }

        public void ClearMenu() 
        {
            System.Console.Clear();
            ShowHeader();
        }
        #endregion
        

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


        #region member
        public void DeleteMember(string line)
        {
            MemberView.DeleteMember(line);
        }
        #endregion

        public void AddBoat()
        {
            BoatView newBoatView =  new BoatView();

            newBoatView.AddBoat();
        }
    }
}
