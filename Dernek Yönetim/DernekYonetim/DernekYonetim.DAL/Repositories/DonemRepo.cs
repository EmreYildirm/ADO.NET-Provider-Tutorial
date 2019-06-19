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
    public class DonemRepo : RepoBase, IRepo<Donem>
    {
        public int Add(Donem item)
        {
            var cmdTxt = string.Format("INSERT INTO Donem(Ay,Yil,Tanim) VALUES(@Ay,@Yil,@Tanim); SELECT SCOPE_IDENTITY()");
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@Ay", item.Ay);
            parameters.Add("@Yil", item.Yil);
            parameters.Add("@Tanim", item.Tanim);
            return provider.ExecuteScalar<int>(cmdTxt,parameters);
        }

        public List<Donem> GetAll()
        {
            var cmdTxt = string.Format("SELECT * FROM Donem");
            DataTable dt= provider.ExecuteAdapter(cmdTxt);
            List<Donem> result = new List<Donem>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                result.Add(new Donem()
                {
                    Id = Convert.ToInt32(dt.Rows[i]["Id"]),
                    Ay = Convert.ToInt32(dt.Rows[i]["Ay"]),
                    Yil = Convert.ToInt32(dt.Rows[i]["Yil"]),
                    Tanim = dt.Rows[i]["Tanim"].ToString()
                });
            }
                
            return result;
        }

        public Donem GetById(int Id)
        {
            var cmdTxt = string.Format("SELECT * FROM Donem WHERE Id=@Id");
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@Id", Id);
            DataTable dt = provider.ExecuteAdapter(cmdTxt,parameters);
            Donem result = null;
            if (dt.Rows.Count>0)
            {
                result = new Donem()
                {
                    Id = Convert.ToInt32(dt.Rows[0]["Id"]),
                    Ay = Convert.ToInt32(dt.Rows[0]["Ay"]),
                    Yil = Convert.ToInt32(dt.Rows[0]["Yil"]),
                    Tanim = dt.Rows[0]["Tanim"].ToString()
                };
            }
            return result;
        }

        public void Remove(Donem item)
        {
            var cmdText = String.Format("DELETE FROM Donem WHERE Id = @Id");
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@Id", item.Id);
            try
            {
                provider.ExecuteNonQuery(cmdText,parameters);
            }
            catch
            {
                throw new Exception(string.Format("{0} ID li Donem silinirken hata olustu.", item.Id));
            }
        }

        public Donem Update(Donem item)
        {
            var cmdTxt = string.Format("UPDATE Donem SET Ay=@Ay,Yil=@Yil,Tanim=@Tanim WHERE Id=@Id");
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@Ay", item.Ay);
            parameters.Add("@Yil", item.Yil);
            parameters.Add("@Yil", item.Yil);
            parameters.Add("@Id", item.Id);
            provider.ExecuteNonQuery(cmdTxt,parameters);
            return GetById(item.Id);
        }

        public Donem GetByMonthAndYear(int ay, int yil)
        {
            var cmdTxt = string.Format("SELECT * FROM Donem WHERE Ay = @Ay AND Yil=@Yil");
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@Ay", ay);
            parameters.Add("@Yil", yil);
            DataTable dt= provider.ExecuteAdapter(cmdTxt, parameters);
            Donem result = null;
            if (dt.Rows.Count>0)
            {
                result = new Donem()
                {
                    Id = Convert.ToInt32(dt.Rows[0]["Id"]),
                    Ay = Convert.ToInt32(dt.Rows[0]["Ay"]),
                    Yil = Convert.ToInt32(dt.Rows[0]["Yil"]),
                    Tanim = dt.Rows[0]["Tanim"].ToString()
                };
            }
            return result;
        }
    }
}