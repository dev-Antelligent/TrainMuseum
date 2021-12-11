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
    public class UploadMuseumVO
    {
        public string museumNo { get; set; }
        public string userID { get; set; }
        public string museumTitle { get; set; }
        public string spectation { get; set; }
        public string museumContents { get; set; }
        public string carType { get; set; }
        public string status { get; set; }
        public string fuelType { get; set; }
        public string carSize { get; set; }
        public DateTime uploadDate { get; set; }
        public string photoFile1 { get; set; }
        public string photoFile2 { get; set; }
        public string photoFile3 { get; set; }
    }
    public class UploadMuseumDAC
    {
        MySqlConnection _SqlCon;

        public UploadMuseumDAC()
        {
            string strConn = ConfigurationManager.ConnectionStrings["project"].ConnectionString;
            _SqlCon = new MySqlConnection(strConn);
            _SqlCon.Open();
        }

        private void FillParameters(MySqlCommand cmd, UploadMuseumVO item)
        {
            MySqlParameter param0 = new MySqlParameter("museumNo", MySqlDbType.Int32);
            param0.Value = item.museumNo;
            cmd.Parameters.Add(param0);

            MySqlParameter param1 = new MySqlParameter("userID", MySqlDbType.VarChar, 15);
            param1.Value = item.userID;
            cmd.Parameters.Add(param1);

            MySqlParameter param2 = new MySqlParameter("museumTitle", MySqlDbType.VarChar, 15);
            param2.Value = item.museumTitle;
            cmd.Parameters.Add(param2);

            MySqlParameter param3 = new MySqlParameter("spectation", MySqlDbType.VarChar, 500);
            param3.Value = item.spectation;
            cmd.Parameters.Add(param3);

            MySqlParameter param4 = new MySqlParameter("museumContents", MySqlDbType.VarChar, 2000);
            param4.Value = item.museumContents;
            cmd.Parameters.Add(param4);

            MySqlParameter param5 = new MySqlParameter("carType", MySqlDbType.VarChar, 15);
            param5.Value = item.carType;
            cmd.Parameters.Add(param5);

            MySqlParameter param6 = new MySqlParameter("status", MySqlDbType.VarChar, 15);
            param6.Value = item.status;
            cmd.Parameters.Add(param6);

            MySqlParameter param7 = new MySqlParameter("fuelType", MySqlDbType.VarChar, 15);
            param7.Value = item.fuelType;
            cmd.Parameters.Add(param7);

            MySqlParameter param8 = new MySqlParameter("carSize", MySqlDbType.VarChar, 15);
            param8.Value = item.carSize;
            cmd.Parameters.Add(param8);

            MySqlParameter param9 = new MySqlParameter("uploadDate", MySqlDbType.DateTime);
            param9.Value = item.uploadDate;
            cmd.Parameters.Add(param9);

            MySqlParameter param10 = new MySqlParameter("photoFile1", MySqlDbType.VarChar, 500);
            param10.Value = item.photoFile1;
            cmd.Parameters.Add(param10);

            MySqlParameter param11 = new MySqlParameter("photoFile2", MySqlDbType.VarChar, 500);
            param11.Value = item.photoFile2;
            cmd.Parameters.Add(param11);

            MySqlParameter param12 = new MySqlParameter("photoFile3", MySqlDbType.VarChar, 500);
            param12.Value = item.photoFile3;
            cmd.Parameters.Add(param12);
        }

        public void Insert(UploadMuseumVO item)
        {
            MySqlTransaction sTrans = _SqlCon.BeginTransaction();

            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Transaction = sTrans;
                cmd.CommandText = " insert into museum( userID, museumTitle, spectation, museumContents, carType, status, fuelType, carSize, uploadDate) values ( @userID, @museumTitle, @spectation, @museumContents, @carType, @status, @fuelType, @carSize, NOW()); select last_insert_id() ";
                cmd.Connection = _SqlCon;
                FillParameters(cmd, item);
                item.museumNo = Convert.ToString(cmd.ExecuteScalar());

                MySqlCommand insertCmd = new MySqlCommand();
                insertCmd.Connection = _SqlCon;
                insertCmd.Transaction = sTrans;
                insertCmd.CommandText = " insert into museumphoto(museumNo, photoFile1, photoFile2, photoFile3) values (@museumNo, @photoFile1, @photoFile2, @photoFile3); ";
                FillParameters(insertCmd, item);
                insertCmd.ExecuteNonQuery();

                sTrans.Commit();
            }
            catch (Exception err)
            {
                sTrans.Rollback();
                throw new Exception(err.Message);
            }
        }
        public void Update(UploadMuseumVO item)
        {
            string sql = " update museum set (museumTitle=@museumTitle, spectation = @spectation, museumContents = @museumContents, carType = @carType, status = @status, fuelType = @fuelType, carSize = @carSize, uploadDate = NOW()) where museumNo = @museumNo; update photo set(photoFile = @photoFile where museumNo = @museumNo; ";
            MySqlCommand cmd = new MySqlCommand(sql, _SqlCon);
            FillParameters(cmd, item);
            cmd.ExecuteNonQuery();
        }
        public void Delete(UploadMuseumVO item)
        {
            string sql = " delete from museum where museumNo = @museumNo; delete from photo where museumNo = @museumNo; ";
            MySqlCommand cmd = new MySqlCommand(sql, _SqlCon);
            FillParameters(cmd, item);
            cmd.ExecuteNonQuery();
        }
    }
}