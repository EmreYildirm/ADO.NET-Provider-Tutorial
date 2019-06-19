using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DernekYonetim.DAL
{
    public interface IQueryBuilder
    {
        string SelectQuery<T>();
        string SelectByIdQuery<T>();
        string Insert<T>();
        string Update<T>();
        string Delete<T>();
    }
}
