using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    class WikiEntities:DbContext
    {
        public WikiEntities()
        {
            Database.Connection.ConnectionString = "Server=localhost;Database=myDataBase;Uid=root;Pwd=max";

        }

        public DbSet<Function> Functions { get; set; }
        public DbSet<Category> Categories { get; set; }


    }
}
