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
    public class YoneticiRepo : RepoBase, IRepo<Yonetici>
    {
        public int Add(Yonetici item)
        {
            var cmdText = "INSERT INTO Yonetici(KisiId,UnvanId,BaslangicTarihi,BitisTarihi) VALUES(@KisiId,@UnvanId,@BaslangicTarihi,@BitisTarihi)";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@KisiId", item.KisiId);
            parameters.Add("@UnvanId", item.UnvanId);
            parameters.Add("@BaslangicTarihi", item.BaslangicTarihi);
            parameters.Add("@BitisTarihi", item.BitisTarihi);
            return provider.ExecuteScalar<int>(cmdText,parameters);
        }

        public List<Yonetici> GetAll()
        {
            var cmdText = "SELECT * FROM Yonetici";
            DataTable dt = provider.ExecuteAdapter(cmdText);
            List<Yonetici> result = new List<Yonetici>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["BitisTarihi"]==DBNull.Value)
                {
                    result.Add(new Yonetici()
                    {
                        Id = Convert.ToInt32(dt.Rows[i]["Id"]),
                        KisiId = Convert.ToInt32(dt.Rows[i]["KisiId"]),
                        UnvanId = Convert.ToInt32(dt.Rows[i]["UnvanId"]),
                        BaslangicTarihi = Convert.ToDateTime(dt.Rows[i]["BaslangicTarihi"])
                    });
                }
                else
                {
                    result.Add(new Yonetici()
                    {
                        Id = Convert.ToInt32(dt.Rows[i]["Id"]),
                        KisiId = Convert.ToInt32(dt.Rows[i]["KisiId"]),
                        UnvanId = Convert.ToInt32(dt.Rows[i]["UnvanId"]),
                        BaslangicTarihi = Convert.ToDateTime(dt.Rows[i]["BaslangicTarihi"]),
                        BitisTarihi = Convert.ToDateTime(dt.Rows[i]["BitisTarihi"])
                    });
                }
            }
                
            return result;
        }

        public Yonetici GetById(int Id)
        {
            var cmdText = ("SELECT * FROM Yonetici WHERE Id=@Id ");
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@Id", Id);
            DataTable dt = provider.ExecuteAdapter(cmdText,parameters);
            Yonetici result = null;
            if(dt.Rows.Count>0)
            {
                if (dt.Rows[0]["BitisTarihi"]==DBNull.Value)
                {
                    result = new Yonetici()
                    {
                        Id = Convert.ToInt32(dt.Rows[0]["Id"]),
                        KisiId = Convert.ToInt32(dt.Rows[0]["KisiId"]),
                        UnvanId = Convert.ToInt32(dt.Rows[0]["UnvanId"]),
                        BaslangicTarihi = Convert.ToDateTime(dt.Rows[0]["BaslangicTarihi"])
                    };
                }
                else
                {
                    result = new Yonetici()
                    {
                        Id = Convert.ToInt32(dt.Rows[0]["Id"]),
                        KisiId = Convert.ToInt32(dt.Rows[0]["KisiId"]),
                        UnvanId = Convert.ToInt32(dt.Rows[0]["UnvanId"]),
                        BaslangicTarihi = Convert.ToDateTime(dt.Rows[0]["BaslangicTarihi"]),
                        BitisTarihi = Convert.ToDateTime(dt.Rows[0]["BitisTarihi"])
                    };
                }
                
            }
            return result;
        }

        public void Remove(Yonetici item)
        {
            var cmdText = "DELETE FROM Yonetici WHERE Id=@Id";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@Id", item.Id);
            provider.ExecuteNonQuery(cmdText,parameters);
        }

        public Yonetici Update(Yonetici item)
        {
            var cmdText = "UPDATE Yonetici SET UnvanId=@UnvanId BaslangicTarihi=@BaslangicTarihi BitisTarihi=@BitisTarihi WHERE Id =@Id ";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@UnvanId", item.UnvanId);
            parameters.Add("@BaslangicTarihi", item.BaslangicTarihi);
            parameters.Add("@BitisTarihi", item.BitisTarihi);
            parameters.Add("@Id", item.Id);
            provider.ExecuteNonQuery(cmdText,parameters);
            return GetById(item.Id);
        }
    }
}
