using DatabazeProjekt.Tabulky;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabazeProjekt
{
    /// <summary>
    /// třída zprostředkující UI
    /// </summary>
    internal class UI
    {
        /// <summary>
        /// metoda na vytvoření menu v konzoli
        /// </summary>
        /// <returns>vrací boolen kvůli následnému pokračování programu </returns>
        public static bool Menu()
        {
            try
            {
                Console.WriteLine("Vyberte akci: \n1.)Přidat \n2.)Změnit \n3.)Odebrat \n4.)Vypsat tabulky \n5.)Import z JSON \n6.)Ukončit program");
                int vyber = Int32.Parse(Console.ReadLine());
                switch (vyber)
                {
                    case 1:
                        UI.Add();
                        break;
                    case 2:
                        UI.Update();
                        break;
                    case 3:
                        UI.Delete();
                        break;
                    case 4:
                        UI.SelectAll();
                        break;
                    case 5:
                        UI.Import();
                        break;
                    case 6:
                        return false;
                }
            }
            catch (Exception ex) {
                Console.WriteLine("Zadejte platnou hodnotu!");
            }
            Console.WriteLine();
            return true;
        }

        /// <summary>
        /// metoda pro vytvoření UI na přidání do databáze
        /// </summary>
        public static void Add()
        {
            try
            {
                Console.WriteLine("Vyberte kam chcete přidat: \n1.)Uzivatel \n2.)Produkt \n3.)Transakce \n4.)Vazební tabulka");
                int vyber = Int32.Parse(Console.ReadLine());
                switch (vyber)
                {
                    case 1:
                        Uzivatel.AddUzivatel();
                        break;
                    case 2:
                        Produkt.AddProdukt();
                        break;
                    case 3:
                        Transakce.AddTransakce();
                        break;
                    case 4:
                        Vazebni_tabulka.AddVazebniTabulka();
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Zadejte platnou hodnotu!");
            }
            Console.WriteLine();
        }
        /// <summary>
        /// metoda pro vytvoření UI na odebrání z databáze
        /// </summary>
        public static void Delete()
        {
            try
            {
                Console.WriteLine("Vyberte kde chcete odebrat: \n1.)Uzivatel \n2.)Produkt \n3.)Transakce \n4.)Vazební tabulka \n5.)Kategorie \n6.)Platebni metoda");
                int vyber = Int32.Parse(Console.ReadLine());
                switch (vyber)
                {
                    case 1:
                        Uzivatel.DeleteUzivatel();
                        break;
                    case 2:
                        Produkt.DeleteProdukt();
                        break;
                    case 3:
                        Transakce.DeleteTransakce();
                        break;
                    case 4:
                        Vazebni_tabulka.DeleteVazebniTabulka();
                        break;
                    case 5:
                        Kategorie.DeleteKategorie();
                        break;
                    case 6:
                        Platebni_metoda.DeletePlatebni_metoda();
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Zadejte platnou hodnotu!");
            }
            Console.WriteLine();
        }

        /// <summary>
        /// metoda pro vytvoření UI na změnu v databázi
        /// </summary>
        public static void Update()
        {
            try
            {
                Console.WriteLine("Vyberte kde chcete upravit: \n1.)Uzivatel \n2.)Produkt \n3.)Transakce \n4.)Vazební tabulka");
                int vyber = Int32.Parse(Console.ReadLine());
                switch (vyber)
                {
                    case 1:
                        Uzivatel.UpdateUzivatel();
                        break;
                    case 2:
                        Produkt.UpdateProdukt();
                        break;
                    case 3:
                        Transakce.UpdateTransakce();
                        break;
                    case 4:
                        Vazebni_tabulka.UpdateVazebniTabulka();
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Zadejte platnou hodnotu!");
            }
            Console.WriteLine();
        }

        /// <summary>
        /// metoda na vyspání všech tabulek
        /// </summary>
        public static void SelectAll()
        {
            Console.WriteLine();
            Uzivatel.Select();
            Produkt.Select();
            Transakce.Select();
            Vazebni_tabulka.Select();
            Platebni_metoda.Select();
            Kategorie.Select();
        }

        /// <summary>
        /// metoda na načtení dat z JSON
        /// </summary>
        public static void Import()
        {
            try
            {
                Console.WriteLine("Chcete importovat do tabulek z JSON: \n1.)Ano \n2.)Ne");
                int vyber = Int32.Parse(Console.ReadLine());
                if (vyber == 1)
                {
                    Kategorie.Load();
                    Platebni_metoda.Load();
                }
            }
            catch (Exception ex) {
                Console.WriteLine("Zadejte platnou hodnotu!");
            }
            
        }
    }
}
