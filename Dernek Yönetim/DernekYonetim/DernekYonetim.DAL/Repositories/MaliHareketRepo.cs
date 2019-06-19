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
    public class MaliHareketRepo : RepoBase, IRepo<MaliHareket>
    {
        public int Add(MaliHareket item)
        {
            var cmdTxt = string.Format("INSERT INTO MaliHareket(KisiId,TipId,Miktar) VALUES(@KisiId,@TipId,@Miktar); SELECT SCOPE_IDENTITY()");
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@KisiId", item.KisiId);
            parameters.Add("@TipId", item.TipId);
            parameters.Add("@Miktar", item.Miktar);
            return provider.ExecuteScalar<int>(cmdTxt,parameters);
        }

        public List<MaliHareket> GetAll()
        {
            var cmdTxt = string.Format("SELECT * FROM MaliHareket");
            DataTable dt = provider.ExecuteAdapter(cmdTxt);
            List<MaliHareket> result = new List<MaliHareket>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                result.Add(new MaliHareket()
                {
                    Id = Convert.ToInt32(dt.Rows[i]["Id"]),
                    KisiId = Convert.ToInt32(dt.Rows[i]["KisiId"]),
                    TipId = Convert.ToInt32(dt.Rows[i]["TipId"]),
                    Miktar = Convert.ToDecimal(dt.Rows[i]["Miktar"])
                });
            }
            return result;
        }

        public MaliHareket GetById(int Id)
        {
            var cmdTxt = string.Format("SELECT * FROM Aidat WHERE Id=@Id");
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@Id", Id);
            DataTable dt = provider.ExecuteAdapter(cmdTxt,parameters);
            MaliHareket result = null;
            if (dt.Rows.Count>0)
            {
                result = new MaliHareket()
                {
                    Id = Convert.ToInt32(dt.Rows[0]["Id"]),
                    KisiId = Convert.ToInt32(dt.Rows[0]["KisiId"]),
                    TipId = Convert.ToInt32(dt.Rows[0]["TipId"]),
                    Miktar = Convert.ToDecimal(dt.Rows[0]["Miktar"])
                };
            }
            return result;
        }

        public void Remove(MaliHareket item)
        {
            var cmdText = String.Format("DELETE FROM MaliHareket WHERE Id = @Id");
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@Id", item.Id);
            try
            {
                provider.ExecuteNonQuery(cmdText,parameters);
            }
            catch
            {
                throw new Exception(String.Format("{0} ID li MaliHareket silinirken hata olustu.", item.Id));
            }
        }

        public MaliHareket Update(MaliHareket item)
        {
            var cmdTxt = string.Format("UPDATE MaliHareket SET KisiId=@KisiId,TipId=@TipId,Miktar=@Miktar WHERE Id=@Id");
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@KisiId", item.KisiId);
            parameters.Add("@TipId", item.TipId);
            parameters.Add("@Miktar", item.Miktar);
            parameters.Add("@Id", item.Id);
            provider.ExecuteNonQuery(cmdTxt,parameters);
            return GetById(item.Id);
        }

        public List<MaliHareket> GetMaliHareketsByKisiId(int KisiId)
        {
            var cmdTxt = string.Format("SELECT * FROM MaliHareket WHERE KisiId= @KisiId");
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@KisiId", KisiId);
            DataTable dt = provider.ExecuteAdapter(cmdTxt,parameters);
            List<MaliHareket> result = new List<MaliHareket>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                result.Add(new MaliHareket()
                {
                    Id = Convert.ToInt32(dt.Rows[i]["Id"]),
                    KisiId = Convert.ToInt32(dt.Rows[i]["KisiId"]),
                    TipId = Convert.ToInt32(dt.Rows[i]["TipId"]),
                    Miktar = Convert.ToDecimal(dt.Rows[i]["Miktar"])
                });
            }
            return result;
        }
    }
}
