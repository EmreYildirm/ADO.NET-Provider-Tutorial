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
    public class HareketTipRepo : RepoBase, IRepo<HareketTip>
    {
        public int Add(HareketTip item)
        {
            var cmdTxt = string.Format("INSERT INTO HareketTip(Tanim) VALUES(@Tanim); SELECT SCOPE_IDENTITY()");
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@Tanim", item.Tanim);
            return provider.ExecuteScalar<int>(cmdTxt,parameters);
        }

        public List<HareketTip> GetAll()
        {
            var cmdTxt = string.Format("SELECT * FROM HareketTip");
            DataTable dt = provider.ExecuteAdapter(cmdTxt);
            List<HareketTip> result = new List<HareketTip>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                result.Add(new HareketTip()
                {
                    Id = Convert.ToInt32(dt.Rows[i]["Id"]),
                    Tanim = dt.Rows[i]["Tanim"].ToString()
                });
            }
            return result;
        }

        public HareketTip GetById(int Id)
        {
            var cmdTxt = string.Format("SELECT * FROM HareketTip WHERE Id=@Id");
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@Id", Id);
            DataTable dt = provider.ExecuteAdapter(cmdTxt,parameters);
            HareketTip result = null;
            if (dt.Rows.Count>0)
            {
                result = new HareketTip()
                {
                    Id = Convert.ToInt32(dt.Rows[0]["Id"]),
                    Tanim = dt.Rows[0]["Tanim"].ToString()
                };
            }
            return result;
        }

        public void Remove(HareketTip item)
        {
            var cmdTxt = string.Format("DELETE FROM HareketTip WHERE Id=@Id");
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@Id", item.Id);
            try
            {
                provider.ExecuteNonQuery(cmdTxt,parameters);
            }
            catch
            {
                throw new Exception(string.Format("{0} Id'li Hareket tipi silinirken hata meydana geldi. İlişkili olduğu satırları gözden geçirin.", item.Id));
            }
        }

        public HareketTip Update(HareketTip item)
        {
            var cmdTxt = string.Format("UPDATE HareketTip SET Tanim=@Tanim WHERE Id=@Id");
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@Id", item.Id);
            parameters.Add("@Tanim", item.Tanim);
            provider.ExecuteNonQuery(cmdTxt,parameters);
            return GetById(item.Id);
        }
        public HareketTip GetByTanim(string tanim)
        {
            var cmdTxt = string.Format("SELECT * FROM HareketTip WHERE Tanim=@Tanim");
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@Tanim", tanim);
            DataTable dt= provider.ExecuteAdapter(cmdTxt, parameters);
            HareketTip result = null;
            if (dt.Rows.Count>0)
            {
                result = new HareketTip()
                {
                    Id = Convert.ToInt32(dt.Rows[0]["Id"]),
                    Tanim = dt.Rows[0]["Tanim"].ToString()
                };
            }
            return result;
        }
    }
}