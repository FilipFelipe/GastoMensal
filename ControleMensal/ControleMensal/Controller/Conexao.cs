using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ControleMensal.Controller
{
    class Conexao
    {
        private static string DATABASE = "CM";
        private static string HOST = "localhost";
        private static string USR = "root";
        private static string PWD = "";
        private static string URL = "server=" + HOST + "; UserId=" + USR + "; password=" + PWD + "; database=" + DATABASE;
        public string sql()
        {
            return URL;
        }

    }
    
}
