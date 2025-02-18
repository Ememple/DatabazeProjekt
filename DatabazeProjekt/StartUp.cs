using DatabazeProjekt.Tabulky;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabazeProjekt
{
    /// <summary>
    /// třída na založení databáze
    /// </summary>
    internal class StartUp
    {
        /// <summary>
        /// metoda na vytvoření tabulek
        /// </summary>
        public static void Start()
        {
            try
            {
                    SqlConnection connection = DatabaseConnection.GetInstance();
                    Console.WriteLine("Pripojeno");

                    //vytvoreni tabulky kategorie
                    String query = "CREATE TABLE kategorie (id int primary key identity(1,1), nazev VARCHAR(50) NOT NULL);";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.ExecuteNonQuery();

                    //vytvoreni tabulky platebni_metoda
                    query = "CREATE TABLE platebni_metoda (id int primary key identity(1,1), typ VARCHAR(20) NOT NULL);";
                    command = new SqlCommand(query, connection);
                    command.ExecuteNonQuery();

                    //vytvoreni tabulky uzivatel
                    query = "CREATE TABLE uzivatel (id int primary key identity(1,1), platebni_metoda_id int foreign key references platebni_metoda(id), jmeno VARCHAR(50) NOT NULL, email VARCHAR(50) NOT NULL, heslo VARCHAR(50) NOT NULL, info VARCHAR(50) NOT NULL);";
                    command = new SqlCommand(query, connection);
                    command.ExecuteNonQuery();

                    //vytvoreni tabulky transakce
                    query = "CREATE TABLE transakce (id int primary key identity(1,1), uzivatel_id int foreign key references uzivatel(id), platebni_metoda_id int foreign key references platebni_metoda(id), stav VARCHAR(20) NOT NULL, datum DATETIME NOT NULL);";
                    command = new SqlCommand(query, connection);
                    command.ExecuteNonQuery();

                    //vytvoreni tabulky produkt
                    query = "CREATE TABLE produkt (id int primary key identity(1,1), uzivatel_id int foreign key references uzivatel(id), transakce_id int foreign key references transakce(id), nazev VARCHAR(50) NOT NULL,popis VARCHAR(50) NOT NULL, cena FLOAT NOT NULL, dostupny BIT NOT NULL);";
                    command = new SqlCommand(query, connection);
                    command.ExecuteNonQuery();

                    //vytvoreni tabulky vazebni_tabulka
                    query = "CREATE TABLE vazebni_tabulka (id int primary key identity(1,1), produkt_id int foreign key references produkt(id), kategorie_id int foreign key references kategorie(id) NOT NULL);";
                    command = new SqlCommand(query, connection);
                    command.ExecuteNonQuery();
                   
            }
            catch (Exception e)
            {
            }
        }
    }
}
