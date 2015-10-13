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
                    string listType;
                    int listTypeInt;

                    listType = MemberListView.SelectListTypeMenu();

                    try
                    {
                        Console.Clear();
                        view.MainView.ShowHeader();

                        if (Int32.TryParse(listType, out listTypeInt))
                        {
                          
                            if (listTypeInt == 1)
                            {
                                MemberListView.ShowCompactList(memberList, boatList);
                                break;
                            }
                            else if (listTypeInt == 2)
                            {
                                MemberListView.ShowVerboseList(memberList, boatList);
                                break;
                            }

                            System.Console.WriteLine("Choose between compact or verbose"); 
                        }

                        System.Console.WriteLine("Must enter a number"); 
                    }
                    catch (Exception)
                    {
                        
                        throw;
                    }
                }
                
                int memberChoiceNumber = MemberListView.SelectMember();

                Member selectedMember = model.DAL.MemberDAL.GetMember(memberChoiceNumber);

                int memberMenuChoice = MemberView.ShowMemberMenu();

                if (memberMenuChoice == 1)
                {
                    MemberView.ShowSpecificMemberInfo(selectedMember, boatList);
                }
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
            if (menuChoice == HappyPirate.view.MainView.Menu.None)
            {
                MainView.ShowMenu();
            }
            return true;

        }

    }
}
