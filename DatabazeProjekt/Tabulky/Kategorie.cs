using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabazeProjekt.Tabulky
{
    /// <summary>
    /// Třída reprezentující tabulku kategorie
    /// </summary>
    internal class Kategorie
    {
        public int ID { get; set; }
        [JsonProperty("nazev")]
        public string Nazev { get; set; }

        /// <summary>
        /// Metoda na načtení dat ze souboru json
        /// </summary>
        public static void Load()
        {
            var kategorieJSON = JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(File.ReadAllText("Kategorie.json"));
            List<string> list = kategorieJSON["kategorie"];
            try
            {
                for (int i = 0; i < list.Count; i++)
                {
                    SqlConnection conn = DatabaseConnection.GetInstance();
                    String query = $"INSERT INTO kategorie (nazev) VALUES ('{list[i]}')";
                    SqlCommand command = new SqlCommand(query, conn);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        /// <summary>
        /// metoda na vyspání tabulky
        /// </summary>
        public static void Select()
        {
            SqlConnection conn = DatabaseConnection.GetInstance();
            String query = "select * from kategorie;";
            SqlCommand command = new SqlCommand(query, conn);
            SqlDataReader reader = command.ExecuteReader();
            Console.WriteLine("Tabulka kategorie");
            Console.WriteLine("ID, Nazev");
            while (reader.Read())
            {
                Console.WriteLine($"{reader.GetInt32(0)}, {reader.GetString(1)}");
            }
            Console.WriteLine();
            reader.Close();
        }

        public static void DeleteKategorie()
        {
            try
            {
                Console.WriteLine("Chcete smazat všechny údaje v kategorie: \n1.)Ano \n2.)Ne");
                int vyber = Int32.Parse(Console.ReadLine());
                if ( vyber == 1)
                {
                    SqlConnection conn = DatabaseConnection.GetInstance();
                    String query = $"delete from kategorie;";
                    SqlCommand command = new SqlCommand(query, conn);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
