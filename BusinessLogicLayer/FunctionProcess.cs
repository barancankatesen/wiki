using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    class FunctionProcess 
    {
        public bool DeleteObjectWithControl(Function ObjectToDelete)
        {
            FunctionRepository FuncRepository = new FunctionRepository();
            if (FuncRepository.DeleteByID(ObjectToDelete.FunctionID)>0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteObjectWithControl(int IDToDelete)
        {
            FunctionRepository FuncRepository = new FunctionRepository();
            if (FuncRepository.DeleteByID(IDToDelete)>0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool SaveObjectWithControl(Function ObjectToSave)
        {
            FunctionRepository FuncRepository = new FunctionRepository();
            if (FuncRepository.Add(ObjectToSave)>0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateObjectWithControl(int IDToSelect, Function ToSave)
        {
            FunctionRepository FuncRepository = new FunctionRepository();
            if (FuncRepository.Update(IDToSelect,ToSave)>0)
            {
                return true;
            }
            return false;
        }
    }
}
