using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStoreMisc
{
    public class UserInfoModel
    {
        public int id = 0;
        public string username = "";
        public string password = "";
        public int role = 0;
        public DateTime reg_date = DateTime.Now;
        public int gender = 1;
        public string mail = "";
        public string tel = "";
        public int enabled = 1;
        public string avatar = "";
        public double balance = 0;

        public UserInfoModel(int id, string username, string password, int role, DateTime reg_date, int gender, string mail, string tel, int enabled, string avatar, double balance)
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