using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DernekYonetim.DAL
{
    public class AdoProvider
    {
        private SqlConnection connection;

        public AdoProvider(string connectionString)
        {
            this.connection = new SqlConnection(connectionString);
        }

        public int ExecuteNonQuery(string commandText,Dictionary<string,object> parameters=null)
        {
            SqlCommand command = new SqlCommand(commandText, connection);
            if(parameters != null)
            {
                foreach (var item in parameters)
                {
                    if (command.CommandText.Contains(item.Key))
                        command.Parameters.AddWithValue(item.Key, item.Value);
                    else
                        throw new ArgumentException(string.Format("Böyle bir parametre bulunamadı : {0}", item.Key));
                }
            }
            int result=default(int);
            try
            {
                OpenConnection();
                result = command.ExecuteNonQuery();
            }
            catch(Exception ex)
            {

            }
            finally
            {
                CloseConnection();
            }
            return result;
        }

        public object ExecuteScalar(string commandText, Dictionary<string, object> parameters = null)
        {
            SqlCommand command = new SqlCommand(commandText,connection);
            if (parameters != null)
            {
                foreach (var item in parameters)
                {
                    if (command.CommandText.Contains(item.Key))
                        command.Parameters.AddWithValue(item.Key, item.Value);
                    else
                        throw new ArgumentException(string.Format("Böyle bir parametre bulunamadı : {0}", item.Key));
                }
            }
            object result=default(object);
            try
            {
                OpenConnection();
                result = command.ExecuteScalar();
            }
            catch(Exception ex)
            {}
            finally
            {
                CloseConnection();
            }
            return result;
        }

        public T ExecuteScalar<T>(string commandText, Dictionary<string, object> parameters=null)
        {
            SqlCommand command = new SqlCommand(commandText, connection);
            if (parameters != null)
            {
                foreach (var item in parameters)
                {
                    if (command.CommandText.Contains(item.Key))
                        command.Parameters.AddWithValue(item.Key, item.Value);
                    else
                        throw new ArgumentException(string.Format("Böyle bir parametre bulunamadı : {0}", item.Key));
                }
            }
            object result=default(T);
            try
            {
                OpenConnection();
                result = command.ExecuteScalar();
            }
            catch(Exception ex)
            {
            }
            finally
            {
                CloseConnection();
            }
            return (T)Convert.ChangeType(result, typeof(T));
        }

        public DataTable ExecuteAdapter(string commandText, Dictionary<string, object> parameters=null)
        {
            SqlCommand command = new SqlCommand(commandText, connection);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter();
            if (parameters != null)
            {
                foreach (var item in parameters)
                {
                    if (command.CommandText.Contains(item.Key))
                        command.Parameters.AddWithValue(item.Key, item.Value);
                    else
                        throw new ArgumentException(string.Format("Böyle bir parametre bulunamadı : {0}", item.Key));
                }
            }
            SqlDataReader result = default(SqlDataReader);
            try
            {
                da.SelectCommand = command;
                da.Fill(dt);
            }
            catch(Exception ex)
            {

            }
            finally
            {
            }
            return dt;
        }

        private void OpenConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
                connection.Open();
        }

        private void CloseConnection()
        {
            if (connection.State != System.Data.ConnectionState.Closed)
                connection.Close();
        }
    }
}