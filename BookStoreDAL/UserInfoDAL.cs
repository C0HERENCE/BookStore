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

        public static int SelectUserCountByID(int userid)
        {
            string sql = "select count(*) from userinfo where id=@userid";
            return (int)SqlHelper.ExecuteScalar(sql, new SqlParameter[]
            {
                new SqlParameter("userid",userid)
            });
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

        public static SqlDataReader SelectUserByID(int id)
        {
            string sql = "select * from userinfo where id=@id";
            return SqlHelper.ExecuteDataReader(sql, new SqlParameter[]
            {
                new SqlParameter("id",id)
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

        public static int UpdateUserInfo(UserInfoModel user)
        {
            string sql = "update userinfo set tel=@tel,gender=@gender,balance=@balance,enabled=@enabled where id = @id";
            return (int)SqlHelper.ExecuteNonQuery(sql, new SqlParameter[] {
                new SqlParameter("tel",user.tel),
                new SqlParameter("gender",user.gender),
                new SqlParameter("balance",user.balance),
                new SqlParameter("id",user.id),
                new SqlParameter("enabled",user.enabled)
            });
        }

        public static int UpdateUserPassword(UserInfoModel user)
        {
            string sql = "update userinfo set password=@newvalue where id = @id";
            return (int)SqlHelper.ExecuteNonQuery(sql, new SqlParameter[] {
                new SqlParameter("newvalue",user.password),
                new SqlParameter("id",user.id),
            });
        }
    }
}