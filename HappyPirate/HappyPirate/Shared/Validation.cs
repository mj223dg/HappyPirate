using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HappyPirate.Shared
{
    class Validation
    {
        public bool validateFirstName(string firstName)
        {
            if (firstName.Length > 25 || String.IsNullOrEmpty(firstName))
            {
                return false;
            }

            return true;
        }

        public bool validateLastName(string lastName)
        {
            if (lastName.Length > 30 || String.IsNullOrEmpty(lastName))
            {
                return false;
            }

            return true;
        }

        public bool validateSocialNumber(string socialNumber)
        {
            if (true)
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
