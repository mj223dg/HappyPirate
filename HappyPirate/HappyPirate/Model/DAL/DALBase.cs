using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace HappyPirate.model.DAL
{
    public abstract class DALBase
    {
        private static string MemberSavePath;

        public DALBase()
        {
            MemberSavePath = Path.Combine(AppDomain.CurrentDomain
                .GetData("APPBASE").ToString(), "members.txt");
        }

        public static string GetMemberSavePath()
        {
            return MemberSavePath;
        }

    }
}
