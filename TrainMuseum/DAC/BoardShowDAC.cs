using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Configuration;

namespace TrainMuseum.DAC
{
    class BoardShowDAC
    {
        MySqlConnection _SqlCon;

        public BoardShowDAC()
        {
            string strConn = ConfigurationManager.ConnectionStrings["project"].ConnectionString;
            _SqlCon = new MySqlConnection(strConn);
            _SqlCon.Open();
        }
        public class BoardShowVO
        {
            public string boardTitle { get; set; }
            public string spectation { get; set; }
            public string boardContents { get; set; }
            public string photoFile1 { get; set; }
            public string photoFile2 { get; set; }
            public string photoFile3 { get; set; }
            public string photoFile4 { get; set; }
            public string photoFile5 { get; set; }
        }

        private void FillParameters(MySqlCommand cmd, string item)
        {
            MySqlParameter param1 = new MySqlParameter("boardTitle", MySqlDbType.VarChar, 15);
            param1.Value = item;
            cmd.Parameters.Add(param1);

            MySqlParameter param2 = new MySqlParameter("boardno", MySqlDbType.Int32);
            param2.Value = item;
            cmd.Parameters.Add(param2);

            MySqlParameter param3 = new MySqlParameter("userid", MySqlDbType.VarChar, 15);
            param3.Value = item;
            cmd.Parameters.Add(param3);
        }

        public DataTable SelectBoard(string title)
        {
            string sql = " select b.boardno, b.userid, b.boardTitle, b.boardContents, p.photofile1, p.photofile2, p.photofile3, p.photofile4, p.photofile5 from board b inner join boardphoto p on b.boardno = p.boardno where boardTitle =@boardTitle; ";

            MySqlCommand cmd = new MySqlCommand(sql, _SqlCon);
            FillParameters(cmd, title);

            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());

            return dt;
        }
        public DataTable SelectReply(string title)
        {
            string sql = " select r.userid, r.replyContents from boardreply r inner join board b on  b.boardno = r.boardno where r.boardno = @boardno; ";

            MySqlCommand cmd = new MySqlCommand(sql, _SqlCon);
            FillParameters(cmd, title);

            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());

            return dt;
        }
    }
}
