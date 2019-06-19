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
    public class ToplantiDetayRepo : RepoBase, IRepo<ToplantiDetay>
    {
        public int Add(ToplantiDetay item)
        {
            var cmdTxt = string.Format("INSERT INTO ToplantiDetay(Konu,Notlar) VALUES(@Konu,@Notlar); SELECT SCOPE_IDENTITY()");
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@Konu", item.Konu);
            parameters.Add("@Notlar", item.Notlar);
            return provider.ExecuteScalar<int>(cmdTxt,parameters);
        }

        public List<ToplantiDetay> GetAll()
        {
            var cmdText = "SELECT * FROM ToplantiDetay";
            DataTable dt= provider.ExecuteAdapter(cmdText);
            List<ToplantiDetay> result = new List<ToplantiDetay>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                result.Add(new ToplantiDetay()
                {
                    Id = Convert.ToInt32(dt.Rows[i]["Id"]),
                    Konu = dt.Rows[i]["Konu"].ToString(),
                    Notlar = dt.Rows[i]["Notlar"].ToString()
                });
            }
                
            return result;
        }

        public ToplantiDetay GetById(int Id)
        {
            var cmdText = ("SELECT * FROM ToplantiDetay WHERE Id=@Id ");
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@Id", Id);
            DataTable dt= provider.ExecuteAdapter(cmdText);
            ToplantiDetay result = null;
            if (dt.Rows.Count > 0)
            {
                result = new ToplantiDetay()
                {
                    Id = Convert.ToInt32(dt.Rows[0]["Id"]),
                    Konu = dt.Rows[0]["Konu"].ToString(),
                    Notlar = dt.Rows[0]["Notlar"].ToString()
                };
            }
            return result;
        }

        public void Remove(ToplantiDetay item)
        {
            var cmdText = "DELETE FROM ToplantiDetay WHERE Id=@Id";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@Id", item.Id);
            provider.ExecuteNonQuery(cmdText,parameters);
        }

        public ToplantiDetay Update(ToplantiDetay item)
        {
            var cmdText = "UPDATE Yonetici SET Konu=@Konu,Notlar=@Notlar  WHERE Id =@Id ";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@Konu", item.Konu);
            parameters.Add("@Notlar", item.Notlar);
            parameters.Add("@Id", item.Id);
            provider.ExecuteNonQuery(cmdText,parameters);
            return GetById(item.Id);
        }
    }
}