using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;
using System.Windows.Forms;

namespace TrainMuseum
{
    public struct Members
    {
        public string ID;
        public string PassWd;
        public string Name;
        public string Email;

        public Members(string userId, string userPw, string userName, string userEmail)
        {
            ID = userId;
            PassWd = userPw;
            Name = userName;
            Email = userEmail;
        }
    }
    public struct Logins
    {
        public string ID;
        public string PassWd;

        public Logins(string userId, string userPw)
        {
            ID = userId;
            PassWd = userPw;
        }
    }

    public struct FindUserID
    {
        public string Name;
        public string Email;

        public FindUserID(string userName, string userEmail)
        {
            Name = userName;
            Email = userEmail;
        }
    }
    public struct FindUserPassWd
    {
        public string ID;
        public string Email;

        public FindUserPassWd(string userId, string userEmail)
        {
            ID = userId;
            Email = userEmail;
        }
    }
    public struct ResetUserPassword
    {
        public string ID;
        public string Password;

        public ResetUserPassword(string userid, string userPassword)
        {
            ID = userid;
            Password = userPassword;
        }
    }

    public class MemberDAC
    {
        MySqlConnection conn;
        public MemberDAC()
        {
            string strConn = ConfigurationManager.ConnectionStrings["project"].ConnectionString;
            conn = new MySqlConnection(strConn);
            conn.Open();
        }

        public void Register(Members member)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = string.Format(" insert into members(userID, userPW, userEmail, userName) values ('{0}', '{1}', '{2}', '{3}'); ", member.ID, member.PassWd, member.Email, member.Name);
            cmd.Connection = conn;
            cmd.ExecuteNonQuery();
        }
        public void Login(Logins login)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = string.Format(" select '{0}', '{1}' from members", login.ID, login.PassWd);
            cmd.Connection = conn;
            cmd.ExecuteNonQuery();
        }

        public string AnswerUserID(FindUserID find)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = string.Format("select userID from members where userName = '{0}' and userEmail = '{1}'", find.Name, find.Email);
            cmd.Connection = conn;
            object result = cmd.ExecuteScalar();
            return (result == null) ? "" : result.ToString();
        }

        public bool FindUserPW(string userid, string useremail)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = string.Format(" select count(*) from members where userID = '{0}' and userEmail = '{1}' ", userid, useremail);
            cmd.Connection = conn;
            int iCnt = Convert.ToInt32(cmd.ExecuteScalar());
            if (iCnt > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void ResetPasswd(ResetUserPassword resetPw)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = String.Format(" UPDATE members SET userPw='{0}' where userid ='{1}'", resetPw.Password, resetPw.ID);
            cmd.Connection = conn;
            cmd.ExecuteNonQuery();
        }

        public bool IsCorrectedID(string userid)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = string.Format(" select count(*) from members where userID = '{0}'", userid);
            cmd.Connection = conn;
            int iCnt = Convert.ToInt32(cmd.ExecuteScalar());
            if (iCnt == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool IsCorrected(string userid, string passwd)
        {
            MySqlCommand cmd = new MySqlCommand();
            passwd = passwd.Replace("\'", "");
            cmd.CommandText = string.Format(" select count(*)from members where userID = '{0}' and userPW = '{1}'", userid, passwd);
            cmd.Connection = conn;
            int iCnt = Convert.ToInt32(cmd.ExecuteScalar());
            if (iCnt == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool IsDuplicated(string userId)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = string.Format(" select count(*) from members where userID = '{0}'", userId);
            cmd.Connection = conn;
            int iCnt = Convert.ToInt32(cmd.ExecuteScalar());
            if (iCnt > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsManager(string userid)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = string.Format(" select count(*) from members where userid = '{0}' and usergrade = '0' ", userid);
            cmd.Connection = conn;
            int iCnt = Convert.ToInt32(cmd.ExecuteScalar());
            if( iCnt >0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsMember(string userid)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = string.Format(" select count(*) from members where userid = '{0}' and (userGrade = '0' or usergrade ='1') ", userid);
            cmd.Connection = conn;
            int iCnt = Convert.ToInt32(cmd.ExecuteScalar());
            if (iCnt > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
