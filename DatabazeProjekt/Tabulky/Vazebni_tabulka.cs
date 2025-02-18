using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabazeProjekt.Tabulky
{
    /// <summary>
    /// Třída reprezentující tabulku vazebni_tabulka
    /// </summary>
    internal class Vazebni_tabulka
    {
        public int ID { get; set; }
        public int Produkt_id { get; set; }
        public int Kategorie_id { get; set; }

        /// <summary>
        /// metoda na vytvoření vazební tabulky
        /// </summary>
        public static void AddVazebniTabulka()
        {
            try
            {
                Console.WriteLine("Zadejte údaje:");
                Console.WriteLine("Zadejte ID produktu");
                int produkt_id = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Zadejte ID kategorie");
                int kategorie_id = Int32.Parse(Console.ReadLine());

                SqlConnection conn = DatabaseConnection.GetInstance();
                String query = $"insert into vazebni_tabulka (produkt_id, kategorie_id) VALUES ({produkt_id},{kategorie_id});";
                SqlCommand command = new SqlCommand(query, conn);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        /// <summary>
        /// metoda na smazání vazební tabulky
        /// </summary>
        public static void DeleteVazebniTabulka()
        {
            try
            {
                Vazebni_tabulka.Select();
                Console.WriteLine("Zadejte ID vazební tabulky:");
                int id = Int32.Parse(Console.ReadLine());

                SqlConnection conn = DatabaseConnection.GetInstance();
                String query = $"delete from vazebni_tabulka where id={id};";
                SqlCommand command = new SqlCommand(query, conn);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        /// <summary>
        /// metoda na upravení hodnoty
        /// </summary>
        public static void UpdateVazebniTabulka()
        {
            try
            {
                Vazebni_tabulka.Select();
                Console.WriteLine("Zadejte údaj, který chcete změnit \n1.)ID produktu \n2.)ID kategorie");
                int zmena = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Zadejte ID:");
                int id = Int32.Parse(Console.ReadLine());
                String query = "";
                switch (zmena)
                {
                    case 1:
                        Console.WriteLine("Zadejte nové ID produktu");
                        int produkt_id = Int32.Parse(Console.ReadLine());
                        query = $"update vazebni_tabulka set produkt_id={produkt_id};";
                        break;
                    case 2:
                        Console.WriteLine("Zadejte nové ID kategorie:");
                        string kategorie_id = Console.ReadLine();
                        query = $"update vazebni_tabulka set kategorie_id='{kategorie_id}';";
                        break;
                }

                SqlConnection conn = DatabaseConnection.GetInstance();
                SqlCommand command = new SqlCommand(query, conn);
                command.ExecuteNonQuery();
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
            String query = "select * from vazebni_tabulka;";
            SqlCommand command = new SqlCommand(query, conn);
            SqlDataReader reader = command.ExecuteReader();
            Console.WriteLine("Tabulka vazebni_tabulka");
            Console.WriteLine("ID, Produkt_id, Kategorie_id");
            while (reader.Read())
            {
                Console.WriteLine($"{reader.GetInt32(0)}, {reader.GetInt32(1)}, {reader.GetInt32(2)}");
            }
            Console.WriteLine();
            reader.Close();
        }
    }
}
