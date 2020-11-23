using System.Data;

namespace ChwJjunJinDam.DataBase
{
    public abstract class DBConnectionManager
    {
        public abstract IDbConnection GetConnection();
    }
}

