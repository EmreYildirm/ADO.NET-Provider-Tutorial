using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DernekYonetim.DAL
{
    public class SqlQueryBuilder : IQueryBuilder
    {
        public string Delete<T>()
        {
            var className = typeof(T).Name;
            return String.Format("DELETE FROM {0} WHERE Id = @Id",className);
        }

        public string Insert<T>()
        {
            Type tip = typeof(T);
            var className = tip.Name;
            var propInfos = tip.GetProperties();
            var strCol = "";
            var strParam = "";
            foreach (var propInfo in propInfos)
            {
                if (propInfo.Name == "Id")
                    continue;
                if (strCol == String.Empty)
                {
                    strCol += propInfo.Name;
                    strParam += "@" + propInfo.Name;
                }
                else
                {
                    strCol += "," + propInfo.Name;
                    strParam += ",@" + propInfo.Name;
                }
            }

            return string.Format("INSERT INTO {0} ({1}) VALUES ({2})", className, strCol, strParam);
        }

        public string SelectByIdQuery<T>()
        {
            return String.Format("{0} WHERE Id = @Id", this.SelectQuery<T>());
        }

        public string SelectQuery<T>()
        {
            var className = typeof(T).Name;
            return string.Format("SELECT * FROM {0}", className);
        }

        public string Update<T>()
        {
            Type tip = typeof(T);
            var className = tip.Name;
            var propInfos = tip.GetProperties();
            var str = "";
            foreach (var propInfo in propInfos)
            {
                if (propInfo.Name == "Id")
                    continue;
                if (str == String.Empty)
                {
                    str += string.Format("{0}=@{0}", propInfo.Name);
                }
                else
                {
                    str += $",{propInfo.Name}=@{propInfo.Name}";
                }
            }

            return String.Format("UPDATE {0} SET {1} WHERE Id = @Id", className, str);
        }
    }
}
