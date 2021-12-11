using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using MySql.Data.MySqlClient;
using TrainMuseum.DAC;
using System.Data;

namespace TrainMuseum.Service
{
    public class TrainmuseumService:IDisposable
    {
        MySqlConnection conn; 
        public TrainmuseumService()
        {
            string strConn = ConfigurationManager.ConnectionStrings["project"].ConnectionString;
            conn = new MySqlConnection(strConn);
            conn.Open();
        }

        public void GetContent(string item)
        {
            MuseumShowDAC dac = new MuseumShowDAC();
            dac.SelectMuseum(item);
        }
        // insert
        public void Insert(UploadMuseumVO item)
        {
            UploadMuseumDAC dac = new UploadMuseumDAC();
            dac.Insert(item);
        }

        // update
        public void Update(UploadMuseumVO item)
        {
            UploadMuseumDAC dac = new UploadMuseumDAC();
            dac.Update(item);
        }

        // delete
        public void Delete(UploadMuseumVO item)
        {
            UploadMuseumDAC dac = new UploadMuseumDAC();
            dac.Delete(item);
        }
        public DataTable SelectAll()
        {
            string sql = "select carType, status, fuelType, carSize, m.museumNo, museumTitle, p.photoFile1 from museum m inner join museumphoto p on m.museumNo = p.museumNo; ";
            MySqlDataAdapter adpt = new MySqlDataAdapter(sql, conn);
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            DataTable dt = new DataTable();
            adpt.Fill(dt);

            return dt;
        }

        //Board
        public void InsertBoard(UploadBoardVO item)
        {
            UploadBoardDAC dac = new UploadBoardDAC(conn);
            dac.InsertBoard(item);
        }

        // update
        public void UpdateBoard(UploadBoardVO item)
        {
            UploadBoardDAC dac = new UploadBoardDAC(conn);
            dac.UpdateBoard(item);
        }

        // delete
        public void DeleteBoard(UploadBoardVO item)
        {
            UploadBoardDAC dac = new UploadBoardDAC(conn);
            dac.DeleteBoard(item);
        }
        public DataTable BoardSelectAll()
        {
            string sql = " select boardType, b.boardNo, b.boardTitle, p.photofile1 from board b inner join boardphoto p on b.boardNo = p.boardNo; ";
            MySqlDataAdapter adpt = new MySqlDataAdapter(sql, conn);
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            DataTable dt = new DataTable();
            adpt.Fill(dt);

            return dt;
        }

        public void Dispose()
        {
            conn.Close();
        }
    }
}
