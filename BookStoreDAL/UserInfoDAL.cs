using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using BookStoreMisc;

namespace BookStoreDAL
{
    public class UserInfoDAL
    {
        public static int SelectUserRole1(string name, string pwd)
        {
            string sql = @"select count(*) from [userinfo] where [role]=1 and [username]=@name and [password]=@pwd";
            SqlParameter[] sqlParameters = new SqlParameter[2];
            sqlParameters[0] = new SqlParameter("name", name);
            sqlParameters[1] = new SqlParameter("pwd", pwd);
            return (int)SqlHelper.ExecuteScalar(sql, sqlParameters);
        }
        public static int SelectUserRole0(string name, string pwd)
        {
            string sql = @"select count(*) from [userinfo] where [role]=0 and [username]=@name and [password]=@pwd";
            SqlParameter[] sqlParameters = new SqlParameter[2];
            sqlParameters[0] = new SqlParameter("name", name);
            sqlParameters[1] = new SqlParameter("pwd", pwd);
            return (int)SqlHelper.ExecuteScalar(sql, sqlParameters);
        }

        public static int SelectUserEnabled(string name)
        {
            string sql = "select enabled from userinfo where username=@name";
            return (int)SqlHelper.ExecuteScalar(sql, new SqlParameter[]
            {
                new SqlParameter("name",name)
            });
        }

        public static int SelectUserIDByName(string name)
        {
            string sql = "select id from userinfo where username=@name";
            return (int)SqlHelper.ExecuteScalar(sql, new SqlParameter[]
            {
                new SqlParameter("name",name)
            });
        }

        public static int SelectUserCountByName(string name)
        {
            string sql = "select count(*) from userinfo where username=@name";
            return (int)SqlHelper.ExecuteScalar(sql, new SqlParameter[]
            {
                new SqlParameter("name",name)
            });
        }

        public static int SelectUserCountByMail(string mail)
        {
            string sql = "select count(*) from userinfo where mail=@mail";
            return (int)SqlHelper.ExecuteScalar(sql, new SqlParameter[]
            {
                new SqlParameter("mail",mail)
            });
        }

        public static int InsertUser(UserInfoModel user)
        {
            string sql = "insert into userinfo values (@username,@password,@role,getdate(),@gender,@mail,@tel,1,@avatar,@balance)";
            return SqlHelper.ExecuteNonQuery(sql, new SqlParameter[]
            {
                new SqlParameter("username",user.username),
                new SqlParameter("password",user.password),
                new SqlParameter("role",user.role),
                new SqlParameter("gender",user.gender),
                new SqlParameter("mail",user.mail),
                new SqlParameter("tel",user.tel),
                new SqlParameter("avatar",user.avatar),
                new SqlParameter("balance",user.balance)
            });
        }
    }
}