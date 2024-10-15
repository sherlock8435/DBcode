using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using WebApplication3.App_code;

namespace WebApplication3
{
    public class User
    {



        public User() { }
        private String ID { get; set; }
        private String FirstName { get; set; }
        private String LastName { get; set; }
        private String Email { get; set; }
        private String Birthday { get; set; }
        private String Gender { get; set; }
        private String State { get; set; }
        private String QuestionAnswer { get; set; }
        private String Password { get; set; }
        private String ConfirmPassword { get; set; }


        public bool isExistUser()
        {
            bool found = false;
            string st = "select * from[USER] where [Email] ='" + this.Email + "'";
            DataTable dt = DBFunction.SelectFromTable(st, "DB.accdb");
            if(dt.Rows.Count > 0 )
                found = true;
            return found;
        }

        public string QuestionRecovery()
        {
            string sqlStr = "";
            sqlStr = "select [Question Pass] from [USER] where[Email] ='"+this.Email + "'";
            DataTable dt = DBFunction.SelectFromTable(sqlStr, "DB.accdb");
            if (dt.Rows.Count > 0)
                return dt.Rows[0][0].ToString();
            return "";
        }

        public string PassRecovery()
        {
            string sqlStr = "";
            sqlStr = "select [Password] from [USER] where[Email] ='" + this.Email + "' and [Question Answer]='"+this.QuestionAnswer+"'";
            DataTable dt = App_code.DBFunction.SelectFromTable(sqlStr, "DB.accdb");
            if (dt.Rows.Count > 0)
                return dt.Rows[0][0].ToString();
            return "";
        }

        public bool UpdatePassword(string newPassword)
        {
            if (this.isExistUser())
            {
                string sqlStr = "update [USER] set [Password] ='"+newPassword+ "'where [Email] ='"+this.Email+"'";
                DBFunction.ChangeTable(sqlStr, "DB.accdb");
                return true;
            }
            return false;
        }
    }
}