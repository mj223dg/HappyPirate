using HappyPirate.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HappyPirate.controller
{
    class Controller
    {
        private view.Console ConsoleView;
        private view.MemberView MemberView;
        private view.MemberListView MemberListView;
        private model.Member MemberModel;

        public Controller(view.Console cV, view.MemberView mV, view.MemberListView mlV, model.Member m)
        {
            ConsoleView = cV;
            MemberView = mV;
            MemberListView = mlV;
            MemberModel = m;
        }

        public bool MenuChoice() 
        {
            ConsoleView.ShowMenu();

            view.Console.Menu menuChoice;

            menuChoice = ConsoleView.GetMenuChoice();

            if (menuChoice == HappyPirate.view.Console.Menu.AddMember)
            {
                ConsoleView.ClearMenu();

                Member newMember = MemberView.AddMember();

                model.DAL.MemberDAL.AddMember(newMember);

            }
            if (menuChoice == HappyPirate.view.Console.Menu.ViewMembers)
            {
                ConsoleView.ClearMenu();
                MemberListView.ShowAllMembers();

                int memberChoiceNumber = MemberListView.SelectMember();

                Member selectedMember = model.DAL.MemberDAL.GetMember(memberChoiceNumber);
                Console.WriteLine(selectedMember.UniqueId);

                int memberMenuChoice = MemberView.ShowMemberMenu();

                if (memberMenuChoice == 2)
                {
                    MemberView.ChangeMember(selectedMember);
                }


                //MemberView.ShowMemberMenu();
                //ConsoleView.ViewMembers();
            }
            if (menuChoice == HappyPirate.view.Console.Menu.AddBoat)
            {
                ConsoleView.ClearMenu();
                ConsoleView.AddBoat();
            }
            if (menuChoice == HappyPirate.view.Console.Menu.None)
            {
                ConsoleView.ShowMenu();
            }
            return true;

        }

    }
}
