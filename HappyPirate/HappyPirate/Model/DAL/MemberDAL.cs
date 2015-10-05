using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace HappyPirate.model.DAL
{
    public class MemberDAL : DALBase
    {
        private static string MemberSavePath = Path.Combine(AppDomain.CurrentDomain
                .GetData("APPBASE").ToString(), "members.txt");

        public static void DALAddMember(Member newMember)
        {
            using (StreamWriter writer = new StreamWriter(MemberSavePath, true))
            {
                writer.WriteLine("{0} {1} {2} {3}", newMember.FirstName, newMember.LastName, newMember.SocialSecurityNumber, newMember.UniqueId);
            }
        }

        public static void DeleteMember(string memberKeyword)
        {
            File.WriteAllLines(MemberSavePath,
                File.ReadLines(MemberSavePath).Where(l => l != memberKeyword).ToList());
        }

        public static void ChangeMember(string memberKeyWord, Member member)
        {
            Console.WriteLine(memberKeyWord);
            List<string> lines = new List<string>(File.ReadAllLines(MemberSavePath));
            int lineIndex = lines.FindIndex(line => line.StartsWith(memberKeyWord));
            System.Console.WriteLine("line index är {0}, memberkeyword är {1}", lineIndex, memberKeyWord);
            System.Console.ReadLine();

            lines[lineIndex] = member.UniqueId + " " + member.FirstName + " " + member.LastName + " " + member.SocialSecurityNumber;
            File.WriteAllLines(MemberSavePath, lines);
        }

        public static Member GetMember(int textFileLineIndex)
        {
            Member member = new Member();
            string[] memberCredentials = new string[3];

            //http://stackoverflow.com/a/1262985
            string lineNumber = File.ReadLines(MemberSavePath).Skip(textFileLineIndex).Take(1).First();

            memberCredentials = lineNumber.Split(' ');

            member.UniqueId = memberCredentials[0];
            member.FirstName = memberCredentials[1];
            member.LastName = memberCredentials[2];
            member.SocialSecurityNumber = memberCredentials[3];

            return member;
        }

    }
}
