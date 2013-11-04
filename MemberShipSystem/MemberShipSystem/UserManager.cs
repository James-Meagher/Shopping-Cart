using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MemberShipSystem
{
    public class UserManager
    {
        private MembershipSystemContext cont = new MembershipSystemContext();
        UserFinder finder = new UserFinder();

        public List<string> CreateUser(string _UserName, string _Password, string _Email, string _SecQuestion, string _SecAnswer, string _PrevOrder, int _UserType)
        {
            if (UserValid(_UserName, _Password, _Email, _SecQuestion, _SecAnswer).Count == 0)
            {
                User d = new User { UserName = _UserName, Password = _Password, Email = _Email, SecQuestion = _SecQuestion, PrevOrder = _PrevOrder, SecAnswer = _SecAnswer, UserType = (MemberPrivilege)_UserType };
                cont.Users.Add(d);
                cont.SaveChanges();
                List<string> strng = new List<string>();
                strng.Add(string.Format("Welcome {0}", _UserName));
                Login(_UserName, _Password);
                return strng;
            }
            else
            {
                return UserValid(_UserName, _Password, _Email, _SecQuestion, _SecAnswer);
            }
        }


        private List<string> UserValid(string UserName, string Password, string Email, string SecQuestion, string SecAnswer)
        {
            List<string> errors = new List<string>();

            UserFinder s = new UserFinder();
            User sds = s.getUserByuserName(UserName);
            if (sds != null)
                errors.Add(string.Format("{0} already exists", sds.UserName));

            User dd = s.getUserByEmail(Email);
            if (dd != null)
                errors.Add(string.Format("{0} already exists", dd.Email));

            errors.Add((SecAnswer == SecQuestion) ? "make the Answer different to the question" : null);
            errors.AddRange(getPasswordStrength(Password).Count > 0 ? getPasswordStrength(Password) : null);
            return errors.Where(ty => !string.IsNullOrWhiteSpace(ty)).Distinct().ToList();
        }
        
        public bool Login(string UserName, string Password)
        {
            User user = finder.getUserByuserName(UserName);
            if (user != null && user.Password == Password)
            {
                HttpContext.Current.Session["User"] = user.UserName;
                HttpContext.Current.Session["Type"] = user.UserType;
                HttpContext.Current.Session["UserId"] = user.UserId;

                ShoppingCart d = (HttpContext.Current.Session["ShoppingCart"] == null) ? ShoppingCart.getShoppingCart(user.UserType) : ReplaceShoppingCart((ShoppingCart)HttpContext.Current.Session["ShoppingCart"], user.UserType);

                HttpContext.Current.Session["ShoppingCart"] = d;
                return true;
            }
            else
            {
                return false;
            }
        }



        private List<string> getPasswordStrength(string Password)
        {
            List<string> lvl = new List<string>();
            int numAmt = 0;
            int SymbolAmt = 0;
            bool hasNumber = false;
            bool hasSymbol = false;
            bool hasMultSymbol = false;
            char[] letters = Password.ToArray<char>();
            lvl.Add((letters.Length > 7) ? null : "Enter at least 8 characters");
            foreach (char character in letters)
            {
                if (!char.IsLetter(character) && char.IsDigit(character))
                {
                    hasNumber = true;
                    numAmt += 1;
                }
                if (char.IsSymbol(character) && !char.IsDigit(character))
                {
                    hasSymbol = true;
                    SymbolAmt += 1;
                }
            }
            hasMultSymbol = (SymbolAmt >= 2) ? true : false;

            lvl.Add((hasNumber) ? null : "Add number for security reasons");
            lvl.Add((hasSymbol) ? null : "Add Symbol for security reasons");
            lvl.Add((hasMultSymbol) ? null : "Add more than one Symbol");
            return lvl;
        }


        public void changeEmail(string email)
        {
            User user = finder.getUserByuserName((string)HttpContext.Current.Session["User"]);
            user.Email = email;
            cont.SaveChanges();
        }

        public void changePassword(string password)
        {
            User user = finder.getUserByuserName((string)HttpContext.Current.Session["User"]);
            user.Password = password;
            cont.SaveChanges();
        }


        public void Logout()
        {
            HttpContext.Current.Session.Clear();
        }


        private ShoppingCart ReplaceShoppingCart(ShoppingCart shoppingCart, MemberPrivilege memberPrivilege)
        {
            ShoppingCart newCart = ShoppingCart.getShoppingCart(memberPrivilege);

            foreach (OrderItem item in shoppingCart.Items)
                newCart.AddItem(item);

            return newCart;
        } 
    }
}