using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace BookStoreDAL
{
    public class LoginDAL
    {
        public static int AdminLogin(string name, string pwd)
        {
            string sql = @"select count(*) from [userinfo] where [role]=1 and [username]=@name and [password]=@pwd";
            SqlParameter[] sqlParameters = new SqlParameter[2];
            sqlParameters[0] = new SqlParameter("name", name);
            sqlParameters[1] = new SqlParameter("pwd", pwd);
            return (int)SqlHelper.ExecuteScalar(sql, sqlParameters);
        }
        public static int UserLogin(string name, string pwd)
        {
            string sql = @"select count(*) from [userinfo] where [role]=0 and [username]=@name and [password]=@pwd";
            SqlParameter[] sqlParameters = new SqlParameter[2];
            sqlParameters[0] = new SqlParameter("name", name);
            sqlParameters[1] = new SqlParameter("pwd", pwd);
            return (int)SqlHelper.ExecuteScalar(sql, sqlParameters);
        }
    }
}