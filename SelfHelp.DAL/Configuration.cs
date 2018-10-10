
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace SelfHelp.DAL
{
    public sealed class Configuration : DbMigrationsConfiguration<DbContext>
    {

        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }


    }

}
