using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Configuration;

namespace TrainMuseum
{
    public class LoadData
    {
        string strConn = ConfigurationManager.ConnectionStrings["project"].ConnectionString;
        public DataTable InfoLoadData()
        {
            DataSet ds = new DataSet();
            using (MySqlConnection conn = new MySqlConnection(strConn))
            {
                string sql = "select codeNo, category, name from codetable";
                
                MySqlDataAdapter adpt = new MySqlDataAdapter(sql, conn);
                conn.Open();
                adpt.Fill(ds, "project");
                conn.Close();
            }
            return ds.Tables["project"];
        }

    }
}
