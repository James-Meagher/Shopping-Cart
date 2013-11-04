using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MemberShipSystem
{
    public class UserFinder
    {
        private MembershipSystemContext cont = new MembershipSystemContext();

        public User getUserByEmail(string email)
        {
            User returnedUser = null;
            using (cont = new MembershipSystemContext())
            {
                returnedUser = (from a in cont.Users
                                where a.Email == email
                                select a).FirstOrDefault();
            }
            return returnedUser;
        }


        public User getUserByuserName(string userName)
        {
            User returnedUser = null;
            using (cont = new MembershipSystemContext())
            {
                returnedUser = (from a in cont.Users
                                where a.UserName == userName
                                select a).FirstOrDefault();
            }
            return returnedUser;
        }
    }
}