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
    public class MuseumShowDAC
    {
        MySqlConnection _SqlCon;

        public MuseumShowDAC()
        {
            string strConn = ConfigurationManager.ConnectionStrings["project"].ConnectionString;
            _SqlCon = new MySqlConnection(strConn);
            _SqlCon.Open();
        }
        public class MuseumShowVO
        {
            public string museumTitle { get; set; }
            public string spectation { get; set; }
            public string museumContents { get; set; }
            public string photoFile1 { get; set; }
            public string photoFile2 { get; set; }
            public string photoFile3 { get; set; }
        }

        private void FillParameters(MySqlCommand cmd, string item)
        {
            MySqlParameter param1 = new MySqlParameter("museumTitle", MySqlDbType.VarChar, 15);
            param1.Value = item;
            cmd.Parameters.Add(param1);
        }

        public DataTable SelectMuseum(string title)
        {
            string sql = " select m.museumNo, m.museumTitle, m.spectation, m.museumContents, p.photofile1, p.photofile2, p.photofile3 from museum m inner join museumphoto p on m.museumno = p.museumno where museumTitle =@museumTitle;" ;
            
            MySqlCommand cmd = new MySqlCommand(sql, _SqlCon);
            FillParameters(cmd, title);

            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());

            return dt;
        }
    }
}
