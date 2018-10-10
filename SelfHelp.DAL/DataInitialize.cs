using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace SelfHelp.DAL
{
    public static class DataInitialize
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DbContext, Configuration>());
            //Database.SetInitializer(new CreateDatabaseIfNotExists<DbContext>());
            //Database.SetInitializer<DbContext>(null);
        }
    }
}
