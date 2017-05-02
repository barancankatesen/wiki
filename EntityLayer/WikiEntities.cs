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
            Database.Connection.ConnectionString = "Server=.;Database=CodeWikiDb;user=sa;password=denemebiriki3";

        }

        public DbSet<Function> Functions { get; set; }
        public DbSet<Category> Categories { get; set; }


    }
}
