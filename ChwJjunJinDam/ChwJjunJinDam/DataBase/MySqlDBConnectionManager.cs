using MySql.Data.MySqlClient;
using System.Data;

namespace ChwJjunJinDam.DataBase
{
    public class MySqlDBConnectionManager : DBConnectionManager
    {
        private readonly string DATA_BASE_URL = $"SERVER=snsserver.cojfv49dbcex.us-east-2.rds.amazonaws.com;DATABASE=hackathon;UID=mspring03;PASSWORD=mspring0517;allow user variables=true";

        public override IDbConnection GetConnection()
        {
            IDbConnection db = new MySqlConnection(DATA_BASE_URL);
            return db;
        }
    }
}
