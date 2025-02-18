using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabazeProjekt
{
    /// <summary>
    /// třída k připojení k databázi
    /// vzato ze školního projektu "DAOC3a"
    /// </summary>
    internal class DatabaseConnection
    {
        private static SqlConnection? conn = null;

        /// <summary>
        /// metoda na připojení k databázi pomocí dat z app.config
        /// </summary>
        /// <returns>konekce k databázi</returns>
        public static SqlConnection GetInstance()
        {
            try
            {
                if (conn == null)
                {
                    SqlConnectionStringBuilder consStringBuilder = new SqlConnectionStringBuilder();
                    consStringBuilder.UserID = ReadSetting("Name");
                    consStringBuilder.Password = ReadSetting("Password");
                    consStringBuilder.InitialCatalog = ReadSetting("Database");
                    consStringBuilder.DataSource = ReadSetting("DataSource");
                    consStringBuilder.ConnectTimeout = 30;
                    conn = new SqlConnection(consStringBuilder.ConnectionString);
                    conn.Open();
                    Console.WriteLine("funguje");
                }
                return conn;
            }
            catch {
                Console.WriteLine("Špatně nastaven App.config");
                Environment.Exit(0);
            }
            return conn;
        }

        /// <summary>
        /// metoda na uzavření konekce s databází
        /// </summary>
        public static void CloseConnection()
        {
            if (conn != null)
            {
                conn.Close();
                conn.Dispose();
                conn = null;
            }
        }
        /// <summary>
        /// metoda na načtení dat z app.config
        /// </summary>
        /// <param name="key"></param>
        /// <returns>data z app.config</returns>
        private static string ReadSetting(string key)
        {
            var appSettings = ConfigurationManager.AppSettings;
            string result = appSettings[key] ?? "Not Found";
            return result;
        }
    }
}
