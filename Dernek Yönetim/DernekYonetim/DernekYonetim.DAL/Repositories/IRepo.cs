using DernekYonetim.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DernekYonetim.DAL.Repositories
{
    public interface IRepo<T>where T:EntityBase,new()
    {
        T GetById(int Id);
        List<T> GetAll();

        int Add(T item);
        T Update(T item);
        void Remove(T item);

    }
}
