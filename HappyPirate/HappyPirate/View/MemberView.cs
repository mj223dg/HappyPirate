using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HappyPirate.model;

namespace HappyPirate.view
{
    class MemberView
    {
        public void ShowMember()
        {

        }

        public model.Member GetMember()
        {
            Member member = new Member(firstName, lastName, socialSecurityNumber);
        }

    }
}
