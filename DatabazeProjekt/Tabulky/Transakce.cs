using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DatabazeProjekt.Tabulky
{
    /// <summary>
    /// Třída reprezentující tabulku transakce
    /// </summary>
    internal class Transakce
    {
        public int ID { get; set; }
        public int Uzivatel_id { get; set; }
        public int Platebni_metoda_id { get; set; }
        public string Stav { get; set; }
        public string Datum { get; set; }

        /// <summary>
        /// metoda na vytvoření transakce
        /// </summary>
        public static void AddTransakce()
        {
            try
            {
                Console.WriteLine("Zadejte údaje:");
                Console.WriteLine("Zadejte ID uživatele");
                int uzivatel_id = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Zadejte ID platební metody");
                int platebni_metoda_id = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Zadejte stav:");
                string stav = Console.ReadLine();
                Console.WriteLine("Zadejte datum ve formátu |yyyy-mm-dd hh:mi:ss|:");
                string datum = Console.ReadLine();
                Regex regex = new Regex("^(\\d{4})\\-(0?[1-9]|1[012])\\-(0?[1-9]|[12][0-9]|3[01]) ([0-1][0-9]|[2][0-3]):([0-5][0-9]):([0-5][0-9])$");
                if (!regex.IsMatch(datum)) {
                    throw new Exception();
                }


                SqlConnection conn = DatabaseConnection.GetInstance();
                String query = $"insert into transakce (uzivatel_id, platebni_metoda_id, stav, datum) VALUES ({uzivatel_id},{platebni_metoda_id},'{stav}','{datum}');";
                SqlCommand command = new SqlCommand(query, conn);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        /// <summary>
        /// metoda na smazání transakce
        /// </summary>
        public static void DeleteTransakce()
        {
            try
            {
                Transakce.Select();
                Console.WriteLine("Zadejte ID transakce:");
                int id = Int32.Parse(Console.ReadLine());

                SqlConnection conn = DatabaseConnection.GetInstance();
                String query = $"delete from transakce where id={id};";
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
        public static void UpdateTransakce()
        {
            try
            {
                Transakce.Select();
                Console.WriteLine("Zadejte ID transakce:");
                int id = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Zadejte údaj, který chcete změnit \n1.)ID uživatele, \n2.)ID platební metody \n3.)stav \n4.)datum");
                int zmena = Int32.Parse(Console.ReadLine());
                String query = "";
                switch (zmena)
                {
                    case 1:
                        Console.WriteLine("Zadejte nové ID uživatele:");
                        int uzivatel_id = Int32.Parse(Console.ReadLine());
                        query = $"update transakce set uzivatel_id={uzivatel_id};";
                        break;
                    case 2:
                        Console.WriteLine("Zadejte nové ID platební metody:");
                        string platebni_metoda_id = Console.ReadLine();
                        query = $"update transakce set platebni_metoda_id={platebni_metoda_id};";
                        break;
                    case 3:
                        Console.WriteLine("Zadejte nový stav:");
                        string stav = Console.ReadLine();
                        query = $"update transakce set stav='{stav}';";
                        break;
                    case 4:
                        Console.WriteLine("Zadejte nové datum:");
                        string datum = Console.ReadLine();
                        query = $"update transakce set datum='{datum}';";
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
            String query = "select * from transakce;";
            SqlCommand command = new SqlCommand(query, conn);
            SqlDataReader reader = command.ExecuteReader();
            Console.WriteLine("Tabulka transakce");
            Console.WriteLine("ID, Uzivatel_id, Platebni_metoda_id, Stav, Datum");
            while (reader.Read())
            {
                Console.WriteLine($"{reader.GetInt32(0)}, {reader.GetInt32(1)}, {reader.GetInt32(2)},{reader.GetString(3)},{reader.GetString(4)}");
            }
            Console.WriteLine();
            reader.Close();
        }

    }
}
