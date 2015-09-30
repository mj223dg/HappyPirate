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
                view.AddMember();
            }
            return true;

        }

    }
}
