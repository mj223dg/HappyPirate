using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HappyPirate.Shared
{
    public abstract class Validation
    {
        public static bool validateString(string stringToValidate, int length)
        {
            if (stringToValidate.Length > length || String.IsNullOrEmpty(stringToValidate) || stringToValidate.Any(char.IsDigit))
            {
                return false;
            }

            return true;
        }

        public static bool validateSocialNumber(string socialNumber)
        {
            if (!socialNumber.All(char.IsDigit) || socialNumber.Length != 10)
            {
                return false;
            }
            
            return true;
        }

        public static bool validateBoatMeasures(string boatMeasures)
        {
            int result;

            if (!Int32.TryParse(boatMeasures, out result) || result <= 0 || result > 50)
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
