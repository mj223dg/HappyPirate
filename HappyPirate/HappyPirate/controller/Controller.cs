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
        private view.BoatView BoatView;
        private view.BoatListView BoatListView;
        private model.Member MemberModel;

        public Controller(view.Console cV, view.MemberView mV, view.MemberListView mlV, model.Member m, view.BoatView bV, view.BoatListView bLV)
        {
            ConsoleView = cV;
            MemberView = mV;
            MemberListView = mlV;
            MemberModel = m;
            BoatView = bV;
            BoatListView = bLV;
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
                if (memberMenuChoice == 3)
                {
                    if (MemberView.DoDeleteMember())
                    {
                        model.DAL.MemberDAL.DeleteMember(selectedMember);
                    }
                }
                if (memberMenuChoice == 4)
                {
                    Boat newBoat = BoatView.AddBoat();
                    newBoat.OwnerId = selectedMember.UniqueId;

                    model.DAL.BoatDAL.AddBoat(newBoat);
                }
                if (memberMenuChoice == 5)
                {
                    List<Boat> boats = model.DAL.BoatDAL.BoatList(selectedMember.UniqueId);
                   
                    BoatListView.ShowBoatsByMember(boats);

                    int selectedBoat = BoatListView.SelectBoat(boats.Count);

                    Boat selectedBoatObject = boats[selectedBoat];
                    int boatMenuChoice = BoatView.ShowBoatMenu();

                    if (boatMenuChoice == 2)
                    {
                        Boat newBoatInfo = BoatView.ChangeBoatInfo();
                        newBoatInfo.OwnerId = selectedMember.UniqueId;

                        model.DAL.BoatDAL.ChangeBoatInfo(selectedBoatObject, newBoatInfo);
                    }
                    if (boatMenuChoice == 3)
                    {
                        model.DAL.BoatDAL.DeleteBoat(selectedBoatObject);
                    }
                }

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
