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
            if (firstName.Length < 0 || firstName.Length > 25 || String.IsNullOrEmpty(firstName))
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
