using RegionAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegionAPI.Repositories
{
  public  interface IRepository<TModel>
    {
        IEnumerable<TModel> GetAll();
        TModel GetSingle(int id);
        TModel Add(TModel toAdd);
        TModel Update(TModel toUpdate);
        void Delete(TModel toDelete);
        int Save();

    }
}
