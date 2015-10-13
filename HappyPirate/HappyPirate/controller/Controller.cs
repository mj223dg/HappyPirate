using HappyPirate.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HappyPirate.controller
{
    class Controller
    {
        private view.MainView MainView;
        private view.MemberView MemberView;
        private view.MemberListView MemberListView;
        private view.BoatView BoatView;
        private view.BoatListView BoatListView;

        public Controller(view.MainView cV, view.MemberView mV, view.MemberListView mlV, view.BoatView bV, view.BoatListView bLV)
        {
            MainView = cV;
            MemberView = mV;
            MemberListView = mlV;
            BoatView = bV;
            BoatListView = bLV;
        }

        public bool MenuChoice() 
        {
            MainView.ShowMenu();

            view.MainView.Menu menuChoice;

            menuChoice = MainView.GetMenuChoice();

            if (menuChoice == HappyPirate.view.MainView.Menu.AddMember)
            {
                MainView.ClearMenu();

                Member newMember = MemberView.AddMember();

                if (newMember != null)
                {
                    model.DAL.MemberDAL.AddMember(newMember); 
                }

            }
            if (menuChoice == HappyPirate.view.MainView.Menu.ViewMembers)
            {
                MainView.ClearMenu();
                Console.WriteLine();
                List<Member> memberList = model.DAL.MemberDAL.MemberList();
                List<Boat> boatList = model.DAL.BoatDAL.BoatList("");

                while (true)
                {
                    HappyPirate.view.MemberListMenu listType;

                    listType = MemberListView.SelectListTypeMenu();

                    try
                    {
                        Console.Clear();
                        view.MainView.ShowHeader();

                        if (listType != HappyPirate.view.MemberListMenu.None)
                        {

                            if (listType == HappyPirate.view.MemberListMenu.Compact)
                            {
                                MemberListView.ShowCompactList(memberList, boatList);
                                break;
                            }
                            else if (listType == HappyPirate.view.MemberListMenu.Verbose)
                            {
                                MemberListView.ShowVerboseList(memberList, boatList);
                                break;
                            }

                            System.Console.WriteLine("Choose between compact or verbose"); 
                        }

                        System.Console.WriteLine("Must enter 1 or 2."); 
                    }
                    catch (Exception)
                    {
                        
                        throw;
                    }
                }
                
                int memberChoiceNumber = MemberListView.SelectMember();

                Member selectedMember = model.DAL.MemberDAL.GetMember(memberChoiceNumber);

                HappyPirate.view.MemberViewMenu memberMenuChoice = MemberView.ShowMemberMenu();

                if (memberMenuChoice == HappyPirate.view.MemberViewMenu.ViewMember)
                {
                    MemberView.ShowSpecificMemberInfo(selectedMember, boatList);
                }
                if (memberMenuChoice == HappyPirate.view.MemberViewMenu.ChangeMember)
                {
                    Member member = MemberView.ChangeMember(selectedMember);
                    model.DAL.MemberDAL.ChangeMember(member.UniqueId, member);

                }
                if (memberMenuChoice == HappyPirate.view.MemberViewMenu.DeleteMember)
                {
                    if (MemberView.DoDeleteMember())
                    {
                        model.DAL.MemberDAL.DeleteMember(selectedMember);
                    }
                }
                if (memberMenuChoice == HappyPirate.view.MemberViewMenu.AddBoat)
                {
                    Boat newBoat = BoatView.AddBoat();
                    newBoat.OwnerId = selectedMember.UniqueId;

                    model.DAL.BoatDAL.AddBoat(newBoat);
                }
                if (memberMenuChoice == HappyPirate.view.MemberViewMenu.ViewBoats)
                {
                    List<Boat> boats = model.DAL.BoatDAL.BoatList(selectedMember.UniqueId);
                   
                    BoatListView.ShowBoatsByMember(boats);

                    int selectedBoat = BoatListView.SelectBoat(boats.Count);

                    Boat selectedBoatObject = boats[selectedBoat];
                    HappyPirate.view.BoatViewMenu boatMenuChoice = BoatView.ShowBoatMenu();

                    if (boatMenuChoice == HappyPirate.view.BoatViewMenu.Change)
                    {
                        Boat newBoatInfo = BoatView.ChangeBoatInfo();
                        newBoatInfo.OwnerId = selectedMember.UniqueId;

                        model.DAL.BoatDAL.ChangeBoatInfo(selectedBoatObject, newBoatInfo);
                    }
                    if (boatMenuChoice == HappyPirate.view.BoatViewMenu.Delete)
                    {
                        model.DAL.BoatDAL.DeleteBoat(selectedBoatObject);
                    }
                }

            }
            if (menuChoice == HappyPirate.view.MainView.Menu.None)
            {
                MainView.ShowMenu();
            }
            return true;

        }

    }
}
