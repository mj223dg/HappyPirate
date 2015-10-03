using HappyPirate.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HappyPirate
{
    class Program
    {
        static void Main(string[] args)
        {
            view.Console view = new view.Console();
            controller.Controller c = new controller.Controller();

            while (c.MenuChoice(view)) ;


        }

    }
}
