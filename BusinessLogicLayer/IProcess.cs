using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    interface IProcess
    {
        bool SaveObjectWithControl(object ObjectToSave);
        bool DeleteObjectWithControl(object ObjectToDelete);
        bool DeleteObjectWithControl(int IDToDelete);
        bool UpdateObjectWithControl(int IDToSelect, object ToSave);
    }
}
