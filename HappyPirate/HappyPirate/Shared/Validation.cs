using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HappyPirate.Shared
{
    public abstract class Validation
    {
        public static bool validateFirstName(string firstName)
        {
            if (firstName.Length > 25 || String.IsNullOrEmpty(firstName))
            {
                return false;
            }

            return true;
        }

        public static bool validateLastName(string lastName)
        {
            if (lastName.Length > 30 || String.IsNullOrEmpty(lastName))
            {
                return false;
            }

            return true;
        }

        public static bool validateSocialNumber(string socialNumber)
        {
            int result;
            bool isNumber = Int32.TryParse(socialNumber, out result);
            if (!isNumber)
            {
                return false;
            }

            return true;
        }

        public static bool validateBoatType(string boatType)
        {
            if (boatType.Length > 30 || String.IsNullOrEmpty(boatType))
            {
                return false;
            }

            return true;
        }

        public static bool validateBoatWidth(string boatWidth)
        {
            int result;

            if (!Int32.TryParse(boatWidth, out result) || result <= 0 || result > 30)
            {
                return false;
            }

            return true;
        }

        public static bool validateBoatLength(string boatLenght)
        {
            int result;

            if (!Int32.TryParse(boatLenght, out result) || result <= 0 || result > 30)
            {
                return false;
            }

            return true;
        }

        public Validation()
        {

        }
    }
}
