using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookStoreMisc;
using BookStoreDAL;

namespace BookStoreBLL
{
    public class LoginBBL
    {
        public static bool Login(string name, string pwd, bool isAdmin)
        {
            pwd = MD5Encrypt.GetMD5(pwd);
            int ans = 0;
            if (isAdmin)
                ans = LoginDAL.AdminLogin(name, pwd);
            else
                ans = LoginDAL.UserLogin(name, pwd);

            if (ans == 0)
                return false;
            else
                return true;
        }
    }
}