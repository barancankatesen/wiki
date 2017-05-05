using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class WikiEntities:DbContext
    {
        public WikiEntities()
            {

            //Database.Connection.ConnectionString = "Server=(localdb)\\mssqllocaldb;AttachDbFileName=C:\\Users\\yazilim\\Documents\\denemem\\database;Integrated Security=true;";

            Database.Connection.ConnectionString = "Server=.;database=WikiCodeDb;user=sa;password=1234";

            //Database.Connection.ConnectionString = "server=.;database=CodeWikiDb;user=sa;password=1234;";

            Database.SetInitializer<WikiEntities>(new CreateDatabaseIfNotExists<WikiEntities>());

        }

        public DbSet<Function> Functions { get; set; }
        public DbSet<Category> Categories { get; set; }


    }
}
