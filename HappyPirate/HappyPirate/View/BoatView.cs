using HappyPirate.model;
using HappyPirate.Shared;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace HappyPirate.view
{
    class BoatView
    {
        public void AddBoat()
        {
            System.Console.WriteLine("Add boat");

            Boat newBoat = InputToBoatObject();

            System.Console.WriteLine("You entered: ");
            System.Console.WriteLine("Boat type:{0}\nBoat length:{1}\nBoat width:{2}", newBoat.Type, newBoat.Width, newBoat.Length);
            System.Console.WriteLine();
            System.Console.WriteLine("Save? (Y for yes, any other key for no)");

            char confirmSave = System.Console.ReadKey().KeyChar;

            if (confirmSave == 'y')
            {
                {
                    model.DAL.BoatDAL.DALAddBoat(newBoat);
                }

                System.Console.WriteLine("Boat saved!");
                System.Console.ReadKey();
            }
        }

        private Boat InputToBoatObject()
        {
            string boatType;
            string width;
            int intWidth;
            string length;
            int intLength;
            //string image;

            while (true)
            {
                System.Console.Write("Enter boat type: ");
                boatType = System.Console.ReadLine();

                try
                {
                    if (Validation.validateString(boatType, 20))
                    {
                        break;
                    }

                    System.Console.WriteLine("Something wrong with boat type");
                }
                catch (Exception)
                {

                    throw;
                }
            }

            while (true)
            {
                System.Console.Write("Enter width: ");
                width = System.Console.ReadLine();

                try
                {
                    if (Validation.validateBoatMeasures(width))
                    {
                        intWidth = int.Parse(width);
                        break;
                    }

                    System.Console.WriteLine("Something wrong with boat width");

                }
                catch (Exception)
                {

                    throw;
                }
            }

            while (true)
            {
                System.Console.Write("Enter length: ");
                length = System.Console.ReadLine();

                try
                {
                    if (Validation.validateBoatMeasures(length))
                    {
                        intLength = int.Parse(length);
                        break;
                    }

                    System.Console.WriteLine("Something wrong with boat length");
                }
                catch (Exception)
                {

                    throw;
                }
            }

            return new Boat(boatType, intWidth, intLength);
        }
    }
}
