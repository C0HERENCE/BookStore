using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookStoreMisc;
using BookStoreDAL;

namespace BookStoreBLL
{
    public class UserInfoBLL
    {
        public static string GetUserCountByNameAndPwd(string name, string pwd, bool isAdmin)
        {
            pwd = MD5Encrypt.GetMD5(pwd);
            string msg = "登录失败, 没有匹配的记录";
            if (isAdmin)
            {
                if (UserInfoDAL.SelectUserRole1(name, pwd) == 1)
                {
                    msg = "登录成功";
                }
            }
            else
            {
                if (UserInfoDAL.SelectUserRole0(name, pwd) == 1)
                {
                    msg = "登录成功";
                }
            }
            if (UserInfoDAL.SelectUserEnabled(name) == 0)
            {
                msg = "你已被封禁";
            }
            return msg;
        }

        public static int GetUserCountByName(string name)
        {
            return UserInfoDAL.SelectUserCountByName(name);
        }

        public static int GetUserCountByMail(string mail)
        {
            return UserInfoDAL.SelectUserCountByMail(mail);
        }

        public static int GetIDByName(string name)
        {
            return UserInfoDAL.SelectUserIDByName(name);
        }

        public static string AddUser(UserInfoModel user)
        {
            string msg = "注册失败";
            if (GetUserCountByName(user.username) > 0)
            {
                msg = "用户名已存在";
                return msg;
            }
            if (GetUserCountByMail(user.mail) > 0)
            {
                msg = "该邮箱已被注册";
                return msg;
            }
            user.password = MD5Encrypt.GetMD5(user.password);
            if (UserInfoDAL.InsertUser(user) > 0)
            {
                msg = "注册成功";
                return msg;
            }
            return msg;
        }

        public static UserInfoModel GetUserInfoByID(int id)
        {
            UserInfoModel user = new UserInfoModel();
            var reader = UserInfoDAL.SelectUserByID(id);
            if (reader == null) return user;
            reader.Read();
            user.id = reader.GetInt32(0);
            user.username = reader.GetString(1);
            user.password = reader.GetString(2);
            user.role = reader.GetInt32(3);
            user.reg_date = reader.GetDateTime(4);
            user.gender = reader.GetInt32(5);
            user.mail = reader.GetString(6);
            user.tel = reader.GetString(7);
            user.enabled = reader.GetInt32(8);
            user.avatar = reader.GetString(9);
            user.balance = reader.GetDouble(10);
            if (!reader.IsClosed) reader.Close();
            return user;
        }

        public static string SetNewPassword(UserInfoModel user)
        {
            string msg = "密码修改失败";
            if (UserInfoDAL.UpdateUserPassword(user) > 0)
            {
                msg = "密码修改成功";
            }
            return msg;
        }

        public static string SetNewInfo(UserInfoModel user)
        {
            string msg = "个人信息修改失败";
            if (UserInfoDAL.UpdateUserInfo(user) > 0)
            {
                msg = "个人信息修改成功";
            }
            return msg;
        }
    }
}