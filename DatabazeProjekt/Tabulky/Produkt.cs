using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabazeProjekt.Tabulky
{
    /// <summary>
    /// Třída reprezentující tabulku produkt
    /// </summary>
    internal class Produkt
    {
        public int ID { get; set; }
        public int Uzivatel_id { get; set; }
        public int Transakce_id { get; set; }
        public string Nazev { get; set; }
        public string Popis { get; set; }
        public float Cena { get; set; }
        public bool Dostupnost { get; set; }

        /// <summary>
        /// metoda na vytvoření produktu
        /// </summary>
        public static void AddProdukt()
        {
            try
            {
                Console.WriteLine("Zadejte údaje:");
                Console.WriteLine("Zadejte ID uživatele");
                int uzivatel_id = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Zadejte ID transakce");
                int transakce_id = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Zadejte název:");
                string nazev = Console.ReadLine();
                Console.WriteLine("Zadejte popis:");
                string popis = Console.ReadLine();
                Console.WriteLine("Zadejte cenu:");
                float cena = float.Parse(Console.ReadLine());
                Console.WriteLine("Zadejte dostupnost: 0.nedostupný 1.dostupný");
                string dostupnost_string = Console.ReadLine();
                bool dostupnost=false;
                if(dostupnost_string == "0" || dostupnost_string == "nedostupny")
                {
                    dostupnost = false;
                }
                else if( dostupnost_string == "1" || dostupnost_string == "dostupny")
                {
                    dostupnost = true;
                }
                

                SqlConnection conn = DatabaseConnection.GetInstance();
                String query = $"insert into produkt (uzivatel_id, transakce_id, nazev, popis, cena, dostupnost) VALUES ({uzivatel_id},{transakce_id},'{nazev}','{popis}',{cena},{dostupnost});";
                SqlCommand command = new SqlCommand(query, conn);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                   Console.WriteLine(ex.Message);
            }

        }

        /// <summary>
        /// metoda na smazání produktu
        /// </summary>
        public static void DeleteProdukt()
        {
            try
            {
                Produkt.Select();
                Console.WriteLine("Zadejte ID produktu:");
                int id = Int32.Parse(Console.ReadLine());

                SqlConnection conn = DatabaseConnection.GetInstance();
                String query = $"delete from produkt where id={id};";
                SqlCommand command = new SqlCommand(query, conn);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine (ex.Message);
            }
        }

        /// <summary>
        /// metoda na upravení hodnoty
        /// </summary>
        public static void UpdateProdukt()
        {
            try
            {
                Produkt.Select();
                Console.WriteLine("Zadejte údaj, který chcete změnit \n1.)ID uživatele, \n2.)ID transakce, \n3.) název, \n4.) Popis, \n5.)Cena, \n6.)Dostupnost");
                int zmena = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Zadejte ID:");
                int id = Int32.Parse(Console.ReadLine());
                String query = "";
                switch (zmena)
                {
                    case 1:
                        Console.WriteLine("Zadejte nové ID uživatele:");
                        int uzivatel_id = Int32.Parse(Console.ReadLine());
                        query = $"update produkt set uzivatel_id={uzivatel_id};";
                        break;
                    case 2:
                        Console.WriteLine("Zadejte nové ID transakce:");
                        string transakce_id = Console.ReadLine();
                        query = $"update produkt set transakce_id={transakce_id};";
                        break;
                    case 3:
                        Console.WriteLine("Zadejte nový název:");
                        string nazev = Console.ReadLine();
                        query = $"update produkt set nazev='{nazev}';";
                        break;
                    case 4:
                        Console.WriteLine("Zadejte nový popis:");
                        string popis = Console.ReadLine();
                        query = $"update produkt set popis='{popis}';";
                        break;
                    case 5:
                        Console.WriteLine("Zadejte novou cenu:");
                        float cena = float.Parse(Console.ReadLine());
                        query = $"update produkt set cena={cena};";
                        break;
                    case 6:
                        Console.WriteLine("Zadejte dostupnost:");
                        string dostupnost_string = Console.ReadLine();
                        bool dostupnost = false;
                        if (dostupnost_string == "0" || dostupnost_string == "nedostupny")
                        {
                            dostupnost = false;
                        }
                        else if (dostupnost_string == "1" || dostupnost_string == "dostupny")
                        {
                            dostupnost = true;
                        }
                        query = $"update produkt set cena={dostupnost};";
                        break;
                }

                SqlConnection conn = DatabaseConnection.GetInstance();
                SqlCommand command = new SqlCommand(query, conn);
                command.ExecuteNonQuery();
            }
            catch (SqlException ex)
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
            String query = "select * from produkt;";
            SqlCommand command = new SqlCommand(query, conn);
            SqlDataReader reader = command.ExecuteReader();
            Console.WriteLine("Tabulka produkt");

            Console.WriteLine("ID, Uzivatel_id, Transakce_id, Nazec, Popis, Cena, Dostupnost");
            while (reader.Read())
            {
                Console.WriteLine($"{reader.GetInt32(0)}, {reader.GetInt32(1)}, {reader.GetInt32(2)},{reader.GetString(3)},{reader.GetString(4)},{reader.GetDouble(5)},{reader.GetBoolean(6)}");
            }
            Console.WriteLine();
            reader.Close();
        }

    }
}
