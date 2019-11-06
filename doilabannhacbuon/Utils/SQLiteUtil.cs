using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLitePCL;

namespace doilabannhacbuon.Utils
{
    class SQLiteUtil
    {
        private const string DatabaseName = "contact.db";

        private static SQLiteUtil _instance;
        public SQLiteConnection Connection { get; }

        public static SQLiteUtil GetIntances()
        {
            if (_instance == null)
            {
                _instance = new SQLiteUtil();
            }
            return _instance;
        }

        private SQLiteUtil()
        {
            Connection = new SQLiteConnection(DatabaseName);
            CreateTables();
        }

        private void CreateTables()
        {
            string sql = @"CREATE TABLE IF NOT EXISTS User (Name VARCHAR( 140 ), PhoneNumber INTEGER UNIQUE NOT NULL);";
            using (var statement = Connection.Prepare(sql))
            {
                statement.Step();
            }
        }
    }
}
