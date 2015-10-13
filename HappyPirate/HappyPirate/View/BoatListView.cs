using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace HappyPirate.view
{
    class BoatListView
    {
        public void ShowBoatsByMember(List<model.Boat> boats)
        {
            int counter = 1;
            System.Console.WriteLine();
            System.Console.WriteLine();
            System.Console.WriteLine("Boat list");
            foreach (var boat in boats)
            {
                System.Console.WriteLine("{0}. {1}, {2}*{3}m", counter, boat.Type, boat.Width, boat.Length);
                //System.Console.WriteLine(counter + ". " + boat.Type + ", " + boat.Width + ", " + "*" + boat.Length);
                counter++;
            }
        }

        public int SelectBoat(int numberOfBoats)
        {
            string selectedBoat;
            int selectedBoatInt;

            while (true)
            {
                System.Console.WriteLine();
                System.Console.Write("Select boat number and press enter: ");
                selectedBoat = System.Console.ReadLine();

                try
                {
                    if (Int32.TryParse(selectedBoat, out selectedBoatInt) && selectedBoatInt > 0 && selectedBoatInt <= numberOfBoats)
                    {
                        return selectedBoatInt - 1;
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }            

        }

    }
}
