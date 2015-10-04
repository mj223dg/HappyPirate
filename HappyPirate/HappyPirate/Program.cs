using HappyPirate.model;
using HappyPirate.view;
using System;
using System.Collections.Generic;
using System.IO;
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

            MemberListView members = new MemberListView();

            members.ShowAllMembers(Path.Combine(AppDomain.CurrentDomain
                .GetData("APPBASE").ToString(), "members.txt"));

            //while (c.MenuChoice(view)) ;


        }

    }
}
