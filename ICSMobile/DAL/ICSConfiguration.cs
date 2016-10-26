using System.Data.Entity;


namespace DAL
{
    class ICSConfiguration: DbConfiguration
    {
        public ICSConfiguration()
        {
            SetProviderServices("MySql.Data.MySqlClient", new MySql.Data.MySqlClient.MySqlProviderServices());
            SetDatabaseInitializer(new ICSInitializer());
        }
    }
}
