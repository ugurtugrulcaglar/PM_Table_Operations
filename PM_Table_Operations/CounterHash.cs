
using Oracle.ManagedDataAccess.Client;
using PM_Table_Operations.Model;

namespace PM_Table_Operations
{

    public class CounterHash
    {
        string connectionString = "Data Source=db.piworks.net:1521/UAT12;User Id=MNP_INDOSAT;Password=mnp;";
        public void GetCounterHash(CounterDefinition obj)
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string sqlQuery = $"select 'C'||to_char(ora_hash(upper('{obj.CounterName}')),'FM0000000000') as hashedCounter  from dual";
                    using (OracleCommand cmd = new OracleCommand(sqlQuery, connection))
                    {
                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                obj.CounterName = reader["hashedCounter"].ToString();

                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Hata: " + ex.Message);
                }
                finally
                {
                    connection.Close();

                }
            }
        }

        public string GetCounterHash(string counter)
        {
            string hashed_counter = "";

            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string sqlQuery = $"select 'C'||to_char(ora_hash(upper('{counter}')),'FM0000000000') as hashedCounter  from dual";
                    using (OracleCommand cmd = new OracleCommand(sqlQuery, connection))
                    {
                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                hashed_counter = reader["hashedCounter"].ToString();
                            }
                        }
                    }
                    return hashed_counter;
                }
                catch (Exception ex)
                {
                    return "Hata: " + ex.Message;
                }
            }
        }
    }
}


