﻿using MySql.Data.MySqlClient;
using System.Data;

namespace ChwJjunJinDam.DataBase
{
    public class MySqlDBConnectionManager : DBConnectionManager
    {
        private readonly string DATA_BASE_URL = $"";

        public override IDbConnection GetConnection()
        {
            IDbConnection db = new MySqlConnection(DATA_BASE_URL);
            return db;
        }
    }
}
