using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;

namespace DataAccessLayer
{
    public class CategoryReposiyory :IRepository
    {
        WikiEntities con = Connection._WikiDbReady();
        public int Add(Category ObjectToAdd)
        {
            con.Categories.Add(ObjectToAdd);
            return con.SaveChanges();
        }

        public int Add(object ObjectToAdd)
        {
            throw new NotImplementedException();
        }

        public int DeleteByID(int IDToDelete)
        {
            Category CategoryToDelete=(Category)con.Categories.SingleOrDefault(t=>t.CategoryID==IDToDelete&&t.isDeleted==false);
            CategoryToDelete.isDeleted = true;
            return con.SaveChanges();
        }

        public List<Category> GetAll()
        {
            return con.Categories.Where(t => t.isDeleted == false).ToList();
        }

        public Category GetByID(int IDToGet)
        {
           return ((Category)con.Categories.SingleOrDefault(t => t.CategoryID == IDToGet && t.isDeleted == false));
        }

        public Category GetByObject(Category ObjectToGet)
        {
            return ((Category)con.Categories.SingleOrDefault(t => t.CategoryID == ObjectToGet.CategoryID && t.isDeleted == false));
        }

        public object GetByObject(object ObjectToGet)
        {
            throw new NotImplementedException();
        }

        public int Update(int IDToSelect, Category ToUpdate)
        {
            Category CategoryToUpdate = con.Categories.SingleOrDefault(t => t.CategoryID == IDToSelect);
            CategoryToUpdate = ToUpdate;

            return con.SaveChanges();
        }

        public int Update(int IDToSelect, object ToUpdate)
        {
            throw new NotImplementedException();
        }

        List<object> IRepository.GetAll()
        {
            throw new NotImplementedException();
        }

        object IRepository.GetByID(int IDToGet)
        {
            throw new NotImplementedException();
        }
    }
}
