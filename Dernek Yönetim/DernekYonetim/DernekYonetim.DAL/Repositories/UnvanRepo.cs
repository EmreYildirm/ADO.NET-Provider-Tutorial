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
    public class UnvanRepo : RepoBase, IRepo<Unvan>
    {
        public int Add(Unvan item)
        {
            var cmdText = "INSERT INTO Unvan(Tanim) VALUES(@Tanim)";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@Tanim", item.Tanim);
            return provider.ExecuteScalar<int>(cmdText,parameters);
        }

        public List<Unvan> GetAll()
        {
            var cmdText = "SELECT * FROM Unvan";
            DataTable dt= provider.ExecuteAdapter(cmdText);
            List<Unvan> result = new List<Unvan>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                result.Add(new Unvan()
                {
                    Id = Convert.ToInt32(dt.Rows[i]["Id"]),
                    Tanim = dt.Rows[i]["Tanim"].ToString()
                });
            }
            return result;
        }

        public Unvan GetById(int Id)
        {
            var cmdText = "SELECT * FROM Unvan WHERE Id=@Id ";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@Id", Id);
            DataTable dt= provider.ExecuteAdapter(cmdText);
            Unvan result = null;
            if (dt.Rows.Count > 0)
            {
                result = new Unvan()
                {
                    Id = Convert.ToInt32(dt.Rows[0]["Id"]),
                    Tanim = dt.Rows[0]["Tanim"].ToString()
                };
            }
            return result;
        }

        public void Remove(Unvan item)
        {
            var cmdText = String.Format("DELETE FROM Unvan WHERE Id = @Id");
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@Id", item.Id);
            try
            {
                provider.ExecuteNonQuery(cmdText);
            }
            catch
            {
                throw new Exception(String.Format("{0} ID li Unvan silinirken hata olustu.", item.Id));
            }
        }

        public Unvan Update(Unvan item)
        {
            var cmdText = "UPDATE Unvan SET Tanim=@Tanim WHERE Id =@Id ";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@Tanim", item.Tanim);
            parameters.Add("@Id", item.Id);
            provider.ExecuteNonQuery(cmdText,parameters);
            return GetById(item.Id);
        }
    }
}
