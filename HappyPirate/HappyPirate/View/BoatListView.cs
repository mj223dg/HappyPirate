using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HappyPirate.view
{
    class BoatListView
    {
        public void ShowBoatsByMember(List<string> boats)
        {
            int counter = 1;
            System.Console.WriteLine();
            System.Console.WriteLine();
            System.Console.WriteLine("Boat list");
            foreach (var boat in boats)
            {
                System.Console.WriteLine("{0}. {1}", counter, boat);
                counter++;
            }
            System.Console.ReadLine();
        }
    }
}
