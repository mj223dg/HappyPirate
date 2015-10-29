using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace HappyPirate.model.DAL
{
    public class MemberDAL
    {
        private static string MemberSavePath = Path.Combine(AppDomain.CurrentDomain
                .GetData("APPBASE").ToString(), "members.txt");

        public static void AddMember(Member newMember)
        {
            using (StreamWriter writer = new StreamWriter(MemberSavePath, true))
            {
                writer.WriteLine("{0} {1} {2} {3}", newMember.UniqueId, newMember.FirstName, newMember.LastName, newMember.SocialSecurityNumber);
            }
        }

        public static void DeleteMember(Member memberToDelete)
        {
            var file = System.IO.File.ReadAllLines(MemberSavePath);
            var fileWithoutMemberToDelete = file.Where(line => !line.Contains(memberToDelete.UniqueId));
            System.IO.File.WriteAllLines(MemberSavePath, fileWithoutMemberToDelete);
        }

        public static void ChangeMember(string memberKeyWord, Member member, bool changeBoat)
        {
            List<string> lines = new List<string>(File.ReadAllLines(MemberSavePath));
            int lineIndex = lines.FindIndex(line => line.StartsWith(memberKeyWord));

            Member oldMember = GetMember(lineIndex);
            Member aMember;

            if (changeBoat)
            {
                aMember = member;
            }
            else
            {
                aMember = oldMember;
            }

            lines[lineIndex] = member.UniqueId + " " + member.FirstName + " " + member.LastName +
                " " + member.SocialSecurityNumber + " " + MakeBoatString(aMember);
            lines[lineIndex] = lines[lineIndex].TrimEnd();
            File.WriteAllLines(MemberSavePath, lines);
        }

        public static string MakeBoatString(Member member)
        {
            string boatString = string.Empty;
            if (member._boats != null)
            {    
                foreach (var boat in member._boats)
                {
                    if (boat != null)
                    {
                        boatString += boat.Type + "|" + boat.Width + "|" + boat.Length + "+";
                    }
                }
                if (!String.IsNullOrWhiteSpace(boatString))
                {                
                    boatString = boatString.Remove(boatString.Length - 1);
                }
            }
            return boatString.TrimEnd();
        }

        public static Member GetMember(int textFileLineIndex)
        {
            Member member = new Member();
            string[] memberCredentials = new string[4];

            //http://stackoverflow.com/a/1262985
            string lineNumber = File.ReadLines(MemberSavePath).Skip(textFileLineIndex).Take(1).First();

            memberCredentials = lineNumber.Split(' ');

            member.UniqueId = memberCredentials[0];
            member.FirstName = memberCredentials[1];
            member.LastName = memberCredentials[2];
            member.SocialSecurityNumber = memberCredentials[3];

            if (memberCredentials.Length == 5)
            {
                string[] memberBoats = memberCredentials[4].Split('+');

                member._boats = ExtractBoats(memberBoats);                
            }
            return member;
        }

        public static List<Member> MemberList()
        {
            List<string> members = System.IO.File
                .ReadAllLines(MemberSavePath)
                .ToList();
            List<Member> memberList = new List<Member>();

            foreach (var member in members)
            {
                string[] memberArray = member.Split(' ');
                Member newMember = new Member(memberArray[0], memberArray[1], memberArray[2], memberArray[3]);
                if (memberArray.Length == 5)
                {
                    newMember._boats = ExtractBoats(memberArray[4].Split('+'));
                }
                memberList.Add(newMember);
            }

            return memberList;
        }

        public static List<Boat> ExtractBoats(string[] memberBoats)
        {
            string[] thisBoat;
            List<Boat> boats = new List<Boat>();
            if (memberBoats.Length != 0)
            {
                foreach (var boatString in memberBoats)
                {
                    if (!String.IsNullOrWhiteSpace(boatString))
                    {
                        thisBoat = boatString.Split('|');
                        Boat boat = new Boat(thisBoat[0], int.Parse(thisBoat[1]), int.Parse(thisBoat[2]));
                        boats.Add(boat);                        
                    }
                }
            }

            return boats;
        }

    }
}
