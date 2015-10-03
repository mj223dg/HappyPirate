using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HappyPirate.controller
{
    class Controller
    {
        public bool MenuChoice(view.Console view) 
        {
            view.ShowMenu();

            view.Console.Menu menuChoice;

            menuChoice = view.GetMenuChoice();
            if (menuChoice == HappyPirate.view.Console.Menu.AddMember)
            {
                view.ClearMenu();
                view.AddMember();
            }
            if (menuChoice == HappyPirate.view.Console.Menu.ViewMembers)
            {
                view.ClearMenu();
                view.ViewMembers();
            }
            if (menuChoice == HappyPirate.view.Console.Menu.AddBoat)
            {
                view.ClearMenu();
                view.AddBoat();
            }
            if (menuChoice == HappyPirate.view.Console.Menu.SearchMember)
            {
                view.ClearMenu();
                view.SearchMember();
            }
            if (menuChoice == HappyPirate.view.Console.Menu.None)
            {
                view.ShowMenu();
            }
            return true;

        }

    }
}
