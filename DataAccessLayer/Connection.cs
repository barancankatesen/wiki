using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;

namespace DataAccessLayer
{
    class Connection
    {
        private static WikiEntities _db = null;
        
        public static WikiEntities _WikiDbReady()
        {
            if (_db==null)
            {
                _db = new WikiEntities();


            }
            return _db;
        }

    }
}
