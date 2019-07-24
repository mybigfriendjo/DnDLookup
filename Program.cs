using System;
using DnDLookup.app;

namespace DnDLookup
{
    public class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            UserSettings.Initialize();

            App dndApp = new App {MainWindow = new MainWindow()};
            dndApp.MainWindow.Show();
            dndApp.Run();
        }
    }
}