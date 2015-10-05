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

        public static void AddBoat(Boat newBoat)
        {
            using (StreamWriter writer = new StreamWriter(BoatSavePath, true))
            {
                writer.WriteLine("{0} {1} {2} {3}", newBoat.OwnerId, newBoat.Type, newBoat.Length, newBoat.Width);
            }
        }

        public static List<string> BoatList(string ownerId)
        {
            return System.IO.File
                .ReadAllLines(BoatSavePath)
                .Where(i => i.Contains(ownerId))
                .ToList();
        }


    }
}
