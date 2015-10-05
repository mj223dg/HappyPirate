using HappyPirate.model;
using HappyPirate.view;
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
            view.Console cV = new view.Console();
            view.MemberView mV = new view.MemberView();
            view.MemberListView mlV = new view.MemberListView();
            view.BoatListView bLV = new view.BoatListView();
            view.BoatView bV = new view.BoatView();
            model.Member m = new model.Member();
            

            controller.Controller c = new controller.Controller(cV, mV, mlV, m, bV, bLV);

            while (c.MenuChoice()) ;
        }

    }
}
