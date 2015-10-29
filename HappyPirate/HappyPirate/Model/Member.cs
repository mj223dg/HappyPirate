using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace HappyPirate.model
{
    public class Member
    {
        private string _firstName;
        private string _lastName;
        private string _socialSecurityNumber;

        public List<Boat> _boats = new List<Boat>();

        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                if (value.Length > 50)
                {
                    throw new Exception("Firstname cannot be longer than 50 characters.");
                }
                _firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                if (value.Length > 100)
                {
                    throw new Exception("Lastname cannot be longer than 100 characters.");
                }
                _lastName = value;
            }

        }

        public string SocialSecurityNumber
        {
            get
            {
                return _socialSecurityNumber;
            }
            set
            {
                if (value.Length > 10)
                {
                    throw new Exception("Social security number should be e.g. YYMMDDSSSS");
                }
                _socialSecurityNumber = value;
            }
        }

        public string UniqueId { get; set; }

        public List<Boat> Boats
        {
            get { return _boats; }
        }

        public Member(string firstName, string lastName, string socialSecurityNumber)
        {
            UniqueId = SetUniqueId();
            FirstName = firstName;
            LastName = lastName;
            SocialSecurityNumber = socialSecurityNumber;
            _boats = new List<Boat>();
        }
        public Member(string uniqueId, string firstName, string lastName, string socialSecurityNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            SocialSecurityNumber = socialSecurityNumber;
            UniqueId = uniqueId;
            _boats = new List<Boat>();
        }

        public Member() { }

        private string SetUniqueId()
        {
            //http://stackoverflow.com/a/1344242

            const string chars = "abcdefghijklmnopqrstuvw0123456789";
            int length = 5;
            var random = new Random();

            string randomString = new string(Enumerable.Repeat(chars, length)
                        .Select(s => s[random.Next(s.Length)]).ToArray());

            string enteredName = randomString;
            string line;

            // Read the file and display it line by line.
            System.IO.StreamReader file = new System.IO.StreamReader(Path.Combine(AppDomain.CurrentDomain
                                            .GetData("APPBASE").ToString(), "members.txt"));

            while ((line = file.ReadLine()) != null)
            {
                if (line.ToLower().Contains(enteredName.ToLower()))
                {
                    System.Console.WriteLine(line);
                }
            }

            file.Close();

            return randomString;
        }

        public void AddBoat(Boat boat)
        {
            Boat newBoat = new Boat(boat.Type, boat.Width, boat.Length);
            _boats.Add(newBoat);
        }
        public void DeleteBoat(int selectedBoatIndex)
        {
            Boats.RemoveAt(selectedBoatIndex);
        }

        public void ChangeBoat(int selectedBoatIndex, Boat newBoat)
        {
            DeleteBoat(selectedBoatIndex);
            AddBoat(newBoat);
        }

    }
}