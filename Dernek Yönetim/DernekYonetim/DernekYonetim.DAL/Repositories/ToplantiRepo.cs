using DernekYonetim.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DernekYonetim.DAL.Repositories
{
    public class ToplantiRepo : RepoBase, IRepo<Toplanti>
    {
        public int Add(Toplanti item)
        {
            var cmdTxt = string.Format("INSERT INTO Toplanti(ToplantiTarihi,Konum) VALUES(@ToplantiTarihi,@Konum); SELECT SCOPE_IDENTITY()");
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@ToplantiTarihi", item.ToplantiTarihi);
            parameters.Add("@Konum", item.Konu);
            return provider.ExecuteScalar<int>(cmdTxt,parameters);
        }

        public List<Toplanti> GetAll()
        {
            var cmdTxt = string.Format("SELECT * FROM Toplanti");
            DataTable dt = provider.ExecuteAdapter(cmdTxt);
            List<Toplanti> result = new List<Toplanti>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                result.Add(new Toplanti()
                {
                    Id = Convert.ToInt32(dt.Rows[i]["Id"]),
                    ToplantiTarihi = Convert.ToDateTime(dt.Rows[i]["ToplantiTarihi"]),
                    Konu = dt.Rows[i]["Konum"].ToString()
                });
            }
            return result;
        }

        public Toplanti GetById(int Id)
        {
            var cmdTxt = string.Format("SELECT * FROM Toplanti WHERE Id=@Id");
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@Id", Id);
            DataTable dt= provider.ExecuteAdapter(cmdTxt,parameters);
            Toplanti result = null;
            if (dt.Rows.Count>0)
            {
                result = new Toplanti()
                {
                    Id = Convert.ToInt32(dt.Rows[0]["Id"]),
                    ToplantiTarihi = Convert.ToDateTime(dt.Rows[0]["ToplantiTarihi"]),
                    Konu = dt.Rows[0]["Konum"].ToString()
                };
            }
            return result;
        }

        public void Remove(Toplanti item)
        {
            var cmdText = String.Format("DELETE FROM Toplanti WHERE Id = @Id");
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@Id", item.Id);
            try
            {
                provider.ExecuteNonQuery(cmdText,parameters);
            }
            catch
            {
                throw new Exception(String.Format("{0} ID li Toplanti silinirken hata olustu.", item.Id));
            }
        }

        public Toplanti Update(Toplanti item)
        {
            var cmdTxt = string.Format("UPDATE Toplanti SET ToplantiTarihi=@ToplantiTarihi,Konum=@Konum WHERE Id=@Id");
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@ToplantiTarihi", item.ToplantiTarihi);
            parameters.Add("@Konum", item.Konu);
            parameters.Add("@Id", item.Id);
            provider.ExecuteNonQuery(cmdTxt,parameters);
            return GetById(item.Id);
        }
    }
}
