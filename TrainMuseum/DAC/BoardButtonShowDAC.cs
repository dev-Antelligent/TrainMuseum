using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using TrainMuseum.Service;

namespace TrainMuseum.DAC
{
    class BoardButtonShowDAC
    {
        MySqlConnection _SqlCon;

        public BoardButtonShowDAC(MySqlConnection sqlCon)
        {
            _SqlCon = sqlCon;
            sqlCon.Open();

            sqlCon.Close();
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
    }
}
