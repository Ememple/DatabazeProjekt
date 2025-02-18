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
    /// Třída reprezentující tabulku platebni_metoda
    /// </summary>
    internal class Platebni_metoda
    {
        public int ID { get; set; }

        [JsonProperty("typ")]
        public string Typ { get; set; }

        /// <summary>
        /// Metoda na načtení dat ze souboru json
        /// </summary>
        public static void Load()
        {
            var platebni_metodyJSON = JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(File.ReadAllText("Platebni_metody.json"));
            List<string> list = platebni_metodyJSON["platebni_metody"];
            try
            {
                SqlConnection conn = DatabaseConnection.GetInstance();
                for (int i = 0; i < list.Count; i++) {
                    String query = $"INSERT INTO platebni_metoda (typ) VALUES ('{list[i]}')";
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
            String query = "select * from platebni_metoda;";
            SqlCommand command = new SqlCommand(query, conn);
            SqlDataReader reader = command.ExecuteReader();
            Console.WriteLine("Tabulka platebni_metoda");
            Console.WriteLine("ID, Typ");
            while (reader.Read())
            {
                Console.WriteLine($"{reader.GetInt32(0)}, {reader.GetString(1)}");
            }
            Console.WriteLine();
            reader.Close();
        }
        public static void DeletePlatebni_metoda()
        {
            try
            {
                Console.WriteLine("Chcete smazat všechny údaje v platebni_metoda: \n1.)Ano \n2.)Ne");
                int vyber = Int32.Parse(Console.ReadLine());
                if (vyber == 1)
                {
                    SqlConnection conn = DatabaseConnection.GetInstance();
                    String query = $"delete from platebni_metoda;";
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
