using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStoreMisc
{
    public class UserInfoModel
    {
        public int id;
        public string username;
        public string password;
        public int role;
        public string reg_date;
        public int gender;
        public string mail;
        public string tel;
        public bool enabled;
        public string avatar;
        public float balance;

        public UserInfoModel(int id, string username, string password, int role, string reg_date, int gender, string mail, string tel, bool enabled, string avatar, float balance)
        {
            this.id = id;
            this.username = username;
            this.password = password;
            this.role = role;
            this.reg_date = reg_date;
            this.gender = gender;
            this.mail = mail;
            this.tel = tel;
            this.enabled = enabled;
            this.avatar = avatar;
            this.balance = balance;
        }

        public UserInfoModel()
        {
        }
    }
}