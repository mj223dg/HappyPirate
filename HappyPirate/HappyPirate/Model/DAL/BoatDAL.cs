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

        public static List<Boat> BoatList(string ownerId)
        {
            List<string> boats = System.IO.File
                .ReadAllLines(BoatSavePath)
                .Where(i => i.Contains(ownerId))
                .ToList();
            List<Boat> boatList = new List<Boat>();

            foreach (var boat in boats)
            {
                string[] boatArray = boat.Split(' ');
                Boat newBoat = new Boat(boatArray[0], boatArray[1], int.Parse(boatArray[2]), int.Parse(boatArray[3]));
                boatList.Add(newBoat);
            }

            return boatList;
        }


    }
}
