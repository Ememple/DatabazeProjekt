using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabazeProjekt.Tabulky
{
    /// <summary>
    /// Třída reprezentující tabulku uzivatel
    /// </summary>
    internal class Uzivatel
    {
        public int ID { get; set; }
        public int Platebni_metoda_id { get; set; }
        public string Jmeno { get; set; }
        public string Email { get; set; }
        public string Heslo { get; set; }
        public string Info { get; set; }

        /// <summary>
        /// metoda na vytvoření uživatele
        /// </summary>
        public static void AddUzivatel() {
            try
            {
                Console.WriteLine("Zadejte údaje:");
                Console.WriteLine("Zadejte ID platební metody");
                int platebni_metoda_id = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Zadejte jméno:");
                string jmeno = Console.ReadLine();
                Console.WriteLine("Zadejte email:");
                string email = Console.ReadLine();
                Console.WriteLine("Zadejte heslo:");
                string heslo = Console.ReadLine();
                Console.WriteLine("Zadejte info:");
                string info = Console.ReadLine();

                SqlConnection conn = DatabaseConnection.GetInstance();
                String query = $"insert into uzivatel (platebni_metoda_id, jmeno, email, heslo, info) VALUES ('{platebni_metoda_id}','{jmeno}','{email}','{heslo}','{info}');";
                SqlCommand command = new SqlCommand(query, conn);
                command.ExecuteNonQuery();
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }

        }

        /// <summary>
        /// metoda na smazání uživatele
        /// </summary>
        public static void DeleteUzivatel()
        {
            try
            {
                Uzivatel.Select();
                Console.WriteLine("Zadejte ID uživatele:");
                int id = Int32.Parse(Console.ReadLine());

                SqlConnection conn = DatabaseConnection.GetInstance();
                String query = $"delete from uzivatel where id={id};";
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
        public static void UpdateUzivatel()
        {
            try
            {
                Uzivatel.Select();
                Console.WriteLine("Zadejte ID uživatele:");
                int id = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Zadejte údaj, který chcete změnit \n1.)PLatebni metoda \n2.)Jmeno \n3.)Email \n4.)Heslo \n5.)Info");
                int zmena = Int32.Parse(Console.ReadLine());
                String query = "";
                switch (zmena) {
                    case 1:
                        Console.WriteLine("Zadejte nové ID platební metody");
                        int platebni_metoda_id = Int32.Parse(Console.ReadLine());
                        query = $"update uzivatel set platebni_metoda_id={platebni_metoda_id};";
                        break;
                    case 2:
                        Console.WriteLine("Zadejte nové jméno:");
                        string jmeno = Console.ReadLine();
                        query = $"update uzivatel set jmeno='{jmeno}';";
                        break;
                    case 3:
                        Console.WriteLine("Zadejte nový email:");
                        string email = Console.ReadLine();
                        query = $"update uzivatel set email='{email}';";
                        break;
                    case 4:
                        Console.WriteLine("Zadejte nové heslo:");
                        string heslo = Console.ReadLine();
                        query = $"update uzivatel set heslo='{heslo}';";
                        break;
                    case 5:
                        Console.WriteLine("Zadejte nové info:");
                        string info = Console.ReadLine();
                        query = $"update uzivatel set info='{info}';";
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
        public static void Select() {
            SqlConnection conn = DatabaseConnection.GetInstance();
            String query = "select * from uzivatel;";
            SqlCommand command = new SqlCommand(query, conn);
            SqlDataReader reader = command.ExecuteReader();
            Console.WriteLine("Tabulka uživatelé");
            Console.WriteLine("ID, Platebni_metoda_id, Jmeno, Email, Heslo, Info");
            while (reader.Read())
            {
                Console.WriteLine($"{reader.GetInt32(0)}, {reader.GetInt32(1)}, {reader.GetString(2)},{reader.GetString(3)},{reader.GetString(4)},{reader.GetString(5)}");
            }
            Console.WriteLine();
            reader.Close();
        }
    }
}
