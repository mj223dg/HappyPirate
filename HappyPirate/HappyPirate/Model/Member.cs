using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HappyPirate.model
{
    class Member
    {
        private string _firstName;
        private string _lastName;
        private string _socialSecurityNumber;
        private string _uniqueId;

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SocialSecurityNumber { get; set; }
        public string UniqueId { get; set; }

        public Member(string firstName, string lastName, string socialSecurityNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            SocialSecurityNumber = socialSecurityNumber;
        }

    }
}