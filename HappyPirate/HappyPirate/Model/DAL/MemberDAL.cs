using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace HappyPirate.model.DAL
{
    public class MemberDAL : DALBase
    {

        public static void DALAddMember(Member newMember)
        {
            using (StreamWriter writer = new StreamWriter(GetMemberSavePath(), true))
            {
                writer.WriteLine("{0} {1} {2} {3}", newMember.FirstName, newMember.LastName, newMember.SocialSecurityNumber, newMember.UniqueId);
            }
        }

        public static void DeleteMember(string memberKeyword)
        {
            File.WriteAllLines(GetMemberSavePath(),
                File.ReadLines(GetMemberSavePath()).Where(l => l != memberKeyword).ToList());
        }

    }
}
