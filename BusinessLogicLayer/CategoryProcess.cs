using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class CategoryProcess 
    {
        
        public static bool DeleteObjectWithControl(Category ObjectToDelete)
        {
            CategoryReposiyory CatReposit = new CategoryReposiyory();
            if (CatReposit.DeleteByID(ObjectToDelete.CategoryID)>0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool DeleteObjectWithControl(int IDToDelete)
        {
            CategoryReposiyory CatReposit = new CategoryReposiyory();
            if (CatReposit.DeleteByID(IDToDelete)>0)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public bool DeleteObjectWithControl(object ObjectToDelete)
        {
            throw new NotImplementedException();
        }

        

        public bool SaveObjectWithControl(Category ObjectToSave)
        {
            CategoryReposiyory CatReposit = new CategoryReposiyory();
            if (CatReposit.Add(ObjectToSave)>0)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public bool SaveObjectWithControl(object ObjectToSave)
        {
            throw new NotImplementedException();
        }

        public bool UpdateObjectWithControl(int IDToSelect, Category ToSave)
        {
            CategoryReposiyory CatReposit = new CategoryReposiyory();
            if (CatReposit.Update(IDToSelect,ToSave)>0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateObjectWithControl(int IDToSelect, object ToSave)
        {
            throw new NotImplementedException();
        }
    }
}
