using Microsoft.Data.SqlClient;
using System.Data;

namespace AMS.Server
{
    public static class DbExtension
    {
        private static string? _connectionString;
        public static void SetConnectionString(string connectionString)
        {
            _connectionString = connectionString;
        }
        public static async Task<DataTableCollection> Execute(this string sql)
        {
            return await Task.Run(() => 
            {
                DataTableCollection tableCollection = null;
                DataSet dt = new();
                using SqlConnection conn = new(_connectionString);
                SqlDataAdapter ada = new(sql, conn);
                try
                {
                    conn.Open();
                    ada.Fill(dt);
                    return dt.Tables;
                }
                catch (SqlException se)
                {
                    return tableCollection;
                }
                finally
                {
                    conn.Close();
                }
            });
        }
    }
}
