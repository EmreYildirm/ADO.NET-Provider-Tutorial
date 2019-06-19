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
    public class UyeRepo : RepoBase, IRepo<Uye>
    {
        public int Add(Uye item)
        {
            var cmdText = "INSERT INTO Uye(KisiId,UyelikBaslangicTarihi,UyelikBitisTarihi,AktifMi) VALUES (@KisiId,@UyelikBaslangicTarihi,@UyelikBitisTarihi,@AktifMi); SELECT SCOPE_IDENTITY()";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@UyelikBaslangicTarihi", item.UyelikBaslangicTarihi);
            parameters.Add("@UyelikBitisTarihi", item.UyelikBitisTarihi);
            parameters.Add("@KisiId", item.KisiId);
            parameters.Add("@AktifMi", item.AktifMi);
            return provider.ExecuteScalar<int>(cmdText,parameters);
        }

        public List<Uye> GetAll()
        {
            var cmdText = "SELECT * FROM Uye";
            DataTable dt = provider.ExecuteAdapter(cmdText);
            List<Uye> result = new List<Uye>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["UyelikBitisTarihi"]==DBNull.Value)
                {
                    result.Add(new Uye()
                    {
                        Id = Convert.ToInt32(dt.Rows[i]["Id"]),
                        KisiId = Convert.ToInt32(dt.Rows[i]["KisiId"]),
                        UyelikBaslangicTarihi = Convert.ToDateTime(dt.Rows[i]["UyelikBaslangicTarihi"]),
                        AktifMi = Convert.ToBoolean(dt.Rows[i]["AktifMi"])
                    });
                }
                else
                {
                    result.Add(new Uye()
                    {
                        Id = Convert.ToInt32(dt.Rows[i]["Id"]),
                        KisiId = Convert.ToInt32(dt.Rows[i]["KisiId"]),
                        UyelikBaslangicTarihi = Convert.ToDateTime(dt.Rows[i]["UyelikBaslangicTarihi"]),
                        UyelikBitisTarihi = Convert.ToDateTime(dt.Rows[i]["UyelikBitisTarihi"]),
                        AktifMi = Convert.ToBoolean(dt.Rows[i]["AktifMi"])
                    });
                     
                }
                    
            } 
            return result;
        }

        public Uye GetById(int Id)
        {
            var cmdText = ("SELECT * FROM Uye WHERE Id=@Id ");
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@Id", Id);
            DataTable dt = provider.ExecuteAdapter(cmdText,parameters);
            Uye result = null;
            if(dt.Rows.Count>0)
            {
                if (dt.Rows[0]["UyelikBitisTarihi"] == DBNull.Value)
                {
                    result = new Uye()
                    {
                        Id = Convert.ToInt32(dt.Rows[0]["Id"]),
                        KisiId = Convert.ToInt32(dt.Rows[0]["KisiId"]),
                        UyelikBaslangicTarihi = Convert.ToDateTime(dt.Rows[0]["UyelikBaslangicTarihi"]),
                        AktifMi = Convert.ToBoolean(dt.Rows[0]["AktifMi"])
                    };
                }
                else
                {
                    result = new Uye()
                    {
                        Id = Convert.ToInt32(dt.Rows[0]["Id"]),
                        KisiId = Convert.ToInt32(dt.Rows[0]["KisiId"]),
                        UyelikBaslangicTarihi = Convert.ToDateTime(dt.Rows[0]["UyelikBaslangicTarihi"]),
                        UyelikBitisTarihi = Convert.ToDateTime(dt.Rows[0]["UyelikBitisTarihi"]),
                        AktifMi = Convert.ToBoolean(dt.Rows[0]["AktifMi"])
                    };
                }
            }
            return result;
        }

        public void Remove(Uye item)
        {
            var cmdText = "DELETE FROM Uye WHERE Id=@Id";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@Id", item.Id);
            try
            {
                provider.ExecuteNonQuery(cmdText,parameters);
            }
            catch (Exception)
            {
                throw new Exception(string.Format("{0} ID li Uye silinirken hata olustu.",item.Id));
            }
        }

        public Uye Update(Uye item)
        {
            var cmdText = "UPDATE Uye SET UyelikBaslangicTarihi=@UyelikBaslangicTarihi, UyelikBitisTarihi=@UyelikBitisTarihi,AktifMi=@AktifMi,KisiId=@KisiId WHERE Id =@Id ";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@UyelikBaslangicTarihi", item.UyelikBaslangicTarihi);
            parameters.Add("@UyelikBitisTarihi", item.UyelikBitisTarihi);
            parameters.Add("@AktifMi", item.AktifMi);
            parameters.Add("@KisiId", item.KisiId);
            parameters.Add("@Id", item.Id);
            provider.ExecuteNonQuery(cmdText,parameters);
            return GetById(item.Id);
        }
    }
}
