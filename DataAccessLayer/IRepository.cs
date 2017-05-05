using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    interface IRepository
    {
        List<object> GetAll();
        object GetByObject(object ObjectToGet);
        object GetByID(int IDToGet);
        int Add(object ObjectToAdd);
        int Update(int IDToSelect, object ToUpdate);
        int DeleteByID(int IDToDelete);
        List<object> SearchByString(string StrToSearch);

    }
}
