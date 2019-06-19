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
    public class KisiRepo : RepoBase, IRepo<Kisi>
    {
        public KisiRepo()
        {
        }

        public int Add(Kisi item)
        {
            var cmdTxt = "INSERT INTO Kisi(Ad,Soyad,Telefon,EMail) VALUES(@Ad,@Soyad,@Telefon,@EMail); SELECT SCOPE_IDENTITY()";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@Ad", item.Ad);
            parameters.Add("@Soyad", item.Soyad);
            parameters.Add("@Telefon", item.Telefon);
            parameters.Add("@EMail", item.EMail);
            return provider.ExecuteScalar<int>(cmdTxt,parameters);
        }

        public List<Kisi> GetAll()
        {
            var cmdTxt = string.Format("SELECT * FROM Kisi");
            DataTable dt= provider.ExecuteAdapter(cmdTxt);
            List<Kisi> result = new List<Kisi>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                result.Add(new Kisi()
                {
                    Id = Convert.ToInt32(dt.Rows[i]["Id"]),
                    Ad = dt.Rows[i]["Ad"].ToString(),
                    Soyad = dt.Rows[i]["Soyad"].ToString(),
                    Telefon = dt.Rows[i]["Telefon"].ToString(),
                    EMail = dt.Rows[i]["EMail"].ToString()
                });
            }
            return result;
        }

        public Kisi GetById(int Id)
        {
            var cmdTxt = "SELECT * FROM Kisi WHERE Id=@Id";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@Id", Id);
            DataTable dt= provider.ExecuteAdapter(cmdTxt,parameters);
            Kisi result = null;
            if (dt.Rows.Count>0)
            {
                result=new Kisi()
                {
                    Id = Convert.ToInt32(dt.Rows[0]["Id"]),
                    Ad = dt.Rows[0]["Ad"].ToString(),
                    Soyad = dt.Rows[0]["Soyad"].ToString(),
                    Telefon = dt.Rows[0]["Telefon"].ToString(),
                    EMail = dt.Rows[0]["EMail"].ToString()
                };
            }
            return result;
        }

        public void Remove(Kisi item)
        {
            var cmdTxt = "DELETE FROM Kisi WHERE Id=@Id";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@Id", item.Id);
            try
            {
                provider.ExecuteNonQuery(cmdTxt,parameters);
            }
            catch
            {
                throw new Exception(string.Format("{0} Id'li Kisi silinirken hata meydana geldi. İlişkili olduğu satırları gözden geçirin.",item.Id));
            }
        }

        public Kisi Update(Kisi item)
        {
            var cmdTxt = "UPDATE Kisi SET Ad=@Ad,Soyad= @Soyad,Telefon=@Telefon,EMail=@EMail WHERE Id=@Id";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@Ad", item.Ad);
            parameters.Add("@Soyad", item.Soyad);
            parameters.Add("@Telefon", item.Telefon);
            parameters.Add("@EMail", item.EMail);
            parameters.Add("@Id", item.Id);
            provider.ExecuteNonQuery(cmdTxt,parameters);
            return GetById(item.Id);
        }
    }
}