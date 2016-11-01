using MySql.Data.Entity;
using System.Data.Common;
using System.Data.Entity;


namespace DAL
{
    public class ICSConfiguration:DbConfiguration
    {
        public ICSConfiguration()
        {
            SetProviderServices("MySql.Data.MySqlClient", new MySql.Data.MySqlClient.MySqlProviderServices());
            SetDatabaseInitializer(new ICSInitializer());
        }
    }
}
