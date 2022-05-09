using System;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;

static class Constants
{
    public const string windowName = "Capstone Project";
    public const int width = 800;
    public const int height = 600;
    public const int StandardButtonHeight = 125;
    public const int StandardButtonWidth = 125;
    public const int AddPartButtonHeight = 25;
    public const int AddPartButtonWidth = 80;
} // Constants



namespace CapstoneApp
{
    class Program
    {

        /*async public static void Test()
        {
            AAPI myClass = new AAPI();
            Console.WriteLine("Show general data for a part (restricted to part 000238 currently):");
            await myClass.getInventoryData(0);
            await myClass.UpdateInventory();
        }*/

        //public static Menu main;
        public static Login login;
        [STAThread]
        static void Main(string[] args)
        {
            //SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            //try
            //{
            //    // Sign into Azure SQL database
            //    builder.DataSource = "capstone-420.database.windows.net";
            //    builder.UserID = "Capstone_420";
            //    builder.Password = "Wsuvan!@";
            //    builder.InitialCatalog = "Capstone_Mock_Database";
            //    builder.MaxPoolSize = 30; // Limit queries to up to 30 at once

            //} // try
            //catch (SqlException err)
            //{
            //    Console.WriteLine(err.ToString());
            //} // catch(SqlException)
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(true);
            //Application.SetHighDpiMode(System.Windows.Forms.HighDpiMode.PerMonitorV2);
            //main = new Menu(builder); // Pass SQL builder to Menu class constructor
            //main.FormLayout();
            //main.Show();
            login = new Login();

            //Test();

            Application.Run();
        } // Main()
    } // Program
} // CapstoneApp
