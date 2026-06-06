using System;
using System.Windows.Forms;
using Orjeen_Stok_Takip.Services;
using Orjeen_Stok_Takip.Views;

namespace Orjeen_Stok_Takip
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            // Initialize Supabase Connection
            SupabaseManager.Initialize();

            Application.Run(new LoginForm());
        }    
    }
}