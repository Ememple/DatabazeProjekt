using DatabazeProjekt.Tabulky;
using System.ComponentModel.Design;
using System.Data.SqlClient;

namespace DatabazeProjekt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StartUp.Start();
            bool continueRunning = true;
            while (continueRunning) { 
                continueRunning = UI.Menu();
            }
        }
    }
}
