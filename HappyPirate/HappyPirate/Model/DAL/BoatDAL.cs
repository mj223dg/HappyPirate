using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace HappyPirate.model.DAL
{
    class BoatDAL : DALBase
    {
        private static string BoatSavePath = Path.Combine(AppDomain.CurrentDomain
                .GetData("APPBASE").ToString(), "boats.txt");

        public static void DALAddBoat(Boat newBoat)
        {
            using (StreamWriter writer = new StreamWriter(BoatSavePath, true))
            {
                writer.WriteLine("{0} {1} {2}", newBoat.Type, newBoat.Length, newBoat.Width);
            }
        }
    }
}
