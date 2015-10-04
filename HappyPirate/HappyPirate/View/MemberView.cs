using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HappyPirate.model;
using System.IO;

namespace HappyPirate.view
{
    class MemberView
    {
        public void ShowMember()
        {

        }

        public Member GetMember(int textFileLineIndex)
        {
            string path = Path.Combine(AppDomain.CurrentDomain
                .GetData("APPBASE").ToString(), "members.txt");

            Member member = new Member();
            string[] memberCrendentials = new string[3];

            //http://stackoverflow.com/a/1262985
            string lineNumber = File.ReadLines(path).Skip(textFileLineIndex).Take(1).First();

            memberCrendentials = lineNumber.Split(' ');

            member.FirstName = memberCrendentials[0];
            member.LastName = memberCrendentials[1];
            member.SocialSecurityNumber = memberCrendentials[2];
            member.UniqueId = memberCrendentials[3];

            return member;
        }

    }
}
