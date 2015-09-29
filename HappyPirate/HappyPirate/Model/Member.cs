using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HappyPirate.Model
{
    class Member
    {
        private string _firstName;
        private string _lastName;
        private int _socialSecurityNumber;
        private string _uniqueId;

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int SocialSecurityNumber { get; set; }
        public string UniqueId { get; set; }
    }
}
