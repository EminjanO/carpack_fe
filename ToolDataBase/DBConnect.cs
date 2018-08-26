using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ToolDataBase
{
    public class DBConnect
    {
        private MySqlConnection db;

        private string _ConnectionString;

        public string ConnectionString
        {
            get { return _ConnectionString; }
            private set { _ConnectionString = value; }
        }

        public DBConnect(string ConnectionString)
        {
            this.ConnectionString = ConnectionString;
            db = new MySqlConnection(ConnectionString);
        }

        private MySqlCommand CreateCommand(Command RequestSQL)
        {
            MySqlCommand cmd = db.CreateCommand();

            cmd.CommandText = RequestSQL.Query;
            cmd.CommandType = System.Data.CommandType.Text;

            foreach (KeyValuePair<string, object> param in RequestSQL.Params)
            {
                MySqlParameter paramSQL = new MySqlParameter(param.Key, param.Value);
                cmd.Parameters.Add(paramSQL);
            }

            return cmd;
        }
        private MySqlCommand SPCreateCommand(Command RequestSQL)
        {
            MySqlCommand cmd = db.CreateCommand();
            cmd.CommandText = RequestSQL.Query;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            foreach (KeyValuePair<string, object> param in RequestSQL.Params)
            {
                MySqlParameter paramSQL = new MySqlParameter(param.Key, param.Value);
                cmd.Parameters.Add(paramSQL);
            }

            return cmd;
        }

        public int ExecuteNonQuery(Command RequestSQL)
        {
            MySqlCommand cmd = CreateCommand(RequestSQL);

            try
            {
                db.Open();

                return cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                db.Close();
            }
        }
        public long getLastId(string query)
        {
            MySqlCommand cmd = db.CreateCommand();
            cmd.CommandText = query;

            try
            {
                db.Open();
                MySqlDataReader reader = cmd.ExecuteReader();

                long id = 0;
                if (reader != null && reader.Read())
                {
                    id = reader.GetInt64(0);
                }
                reader.Close();

                return id;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                db.Close();
            }
        }

        public Data ExecuteScalar<Data>(Command RequestSQL)
        {
            MySqlCommand cmd = CreateCommand(RequestSQL);

            try
            {
                db.Open();

                return (Data)cmd.ExecuteScalar();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                db.Close();
            }
        }

        public List<Dictionary<string, object>> ExecuteReader(Command RequestSQL)
        {
            MySqlCommand cmd = CreateCommand(RequestSQL);

            List<Dictionary<string, object>> results = new List<Dictionary<string, object>>();

            try
            {
                db.Open();

                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Dictionary<string, object> row = new Dictionary<string, object>();

                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        string key = reader.GetName(i);
                        object value = reader[i];

                        row.Add(key, value);
                    }

                    results.Add(row);
                }
                reader.Close();

                return results;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                db.Close();
            }
        }
        public List<Dictionary<string, object>> SPExecuteReader(Command RequestSQL)
        {
            MySqlCommand cmd = SPCreateCommand(RequestSQL);

            List<Dictionary<string, object>> results = new List<Dictionary<string, object>>();

            try
            {
                db.Open();

                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Dictionary<string, object> row = new Dictionary<string, object>();

                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        string key = reader.GetName(i);
                        object value = reader[i];

                        row.Add(key, value);
                    }

                    results.Add(row);
                }
                reader.Close();

                return results;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                db.Close();
            }
        }
    }
}
