using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace TrainMuseum.DAC
{
    public class UploadBoardVO
    {
        public string boardNo { get; set; }
        public string userID { get; set; }
        public string boardTitle { get; set; }
        public string boardContents { get; set; }
        public string boardType { get; set; }
        public string photoFile1 { get; set; }
        public string photoFile2 { get; set; }
        public string photoFile3 { get; set; }
        public string photoFile4 { get; set; }
        public string photoFile5 { get; set; }
    }
    public class UploadBoardDAC
    {
        MySqlConnection _sqlCon;
        public UploadBoardDAC(MySqlConnection sqlCon)
        {
            _sqlCon = sqlCon;
        }

        private void FillParameters(MySqlCommand cmd, UploadBoardVO item)
        {
            MySqlParameter param0 = new MySqlParameter("boardNo", MySqlDbType.Int32);
            param0.Value = item.boardNo;
            cmd.Parameters.Add(param0);

            MySqlParameter param1 = new MySqlParameter("userID", MySqlDbType.VarChar, 15);
            param1.Value = item.userID;
            cmd.Parameters.Add(param1);

            MySqlParameter param2 = new MySqlParameter("boardTitle", MySqlDbType.VarChar, 15);
            param2.Value = item.boardTitle;
            cmd.Parameters.Add(param2);

            MySqlParameter param3 = new MySqlParameter("boardContents", MySqlDbType.VarChar, 1000);
            param3.Value = item.boardContents;
            cmd.Parameters.Add(param3);

            MySqlParameter param4 = new MySqlParameter("boardType", MySqlDbType.Int32);
            param4.Value = item.boardType;
            cmd.Parameters.Add(param4);

            MySqlParameter param5 = new MySqlParameter("photoFile1", MySqlDbType.VarChar, 500);
            param5.Value = item.photoFile1;
            cmd.Parameters.Add(param5);

            MySqlParameter param6 = new MySqlParameter("photoFile2", MySqlDbType.VarChar, 500);
            param6.Value = item.photoFile2;
            cmd.Parameters.Add(param6);

            MySqlParameter param7 = new MySqlParameter("photoFile3", MySqlDbType.VarChar, 500);
            param7.Value = item.photoFile3;
            cmd.Parameters.Add(param7);

            MySqlParameter param8 = new MySqlParameter("photoFile4", MySqlDbType.VarChar, 500);
            param8.Value = item.photoFile4;
            cmd.Parameters.Add(param8);

            MySqlParameter param9 = new MySqlParameter("photoFile5", MySqlDbType.VarChar, 500);
            param9.Value = item.photoFile5;
            cmd.Parameters.Add(param9);
        }
        public void InsertBoard(UploadBoardVO item)
        {
            MySqlTransaction sTrans = _sqlCon.BeginTransaction();
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Transaction = sTrans;
                cmd.CommandText = "insert into board(userID, boardTitle, boardContents, boardType, uploaddate) values (@userID, @boardTitle, @boardContents, @boardType, NOW()); select last_insert_id(); ";
                cmd.Connection = _sqlCon;
                FillParameters(cmd, item);
                item.boardNo = Convert.ToString(cmd.ExecuteScalar());

                MySqlCommand insertCmd = new MySqlCommand();
                insertCmd.Connection = _sqlCon;
                insertCmd.Transaction = sTrans;
                insertCmd.CommandText = " insert into boardphoto(boardNo, photoFile1, photoFile2, photoFile3, photoFile4, photoFile5) values (@boardNo, @photoFile1, @photoFile2, @photoFile3, @photoFile4, @photoFile5); ";
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

        public void UpdateBoard(UploadBoardVO item)
        {
            string sql = " update board set (boardTitle=@boardTitle, boardContents = @boardContents, uploadDate = NOW()) where boardNo = @boardNo; update photo set(photoFile = @photoFile where boardNo = @boardNo; ";
            MySqlCommand cmd = new MySqlCommand(sql, _sqlCon);
            FillParameters(cmd, item);
            cmd.ExecuteNonQuery();
        }

        public void DeleteBoard(UploadBoardVO item)
        {
            string sql = " delete from board where boardNo = @boardNo; delete from photo where boardNo = @boardNo; ";
            MySqlCommand cmd = new MySqlCommand(sql, _sqlCon);
            FillParameters(cmd, item);
            cmd.ExecuteNonQuery();
        }
    }
}
