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
        private static string BoatSavePath;

        public DALBase()
        {
            MemberSavePath = Path.Combine(AppDomain.CurrentDomain
                .GetData("APPBASE").ToString(), "members.txt");

            BoatSavePath = Path.Combine(AppDomain.CurrentDomain
                .GetData("APPBASE").ToString(), "boats.txt");
        }

        public static string GetMemberSavePath()
        {
            return MemberSavePath;
        }

        public static string GetBoatSavePath()
        {
            return BoatSavePath;
        }

    }
}
