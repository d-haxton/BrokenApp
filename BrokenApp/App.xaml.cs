using System.Data.SQLite;
using System.Windows;

namespace BrokenApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void App_OnStartup(object sender, StartupEventArgs e)
        {
            var connection = new SQLiteConnection("Data Source=brokenapp.db;Version=3;foreign keys=true;DateTimeKind=Utc");
            connection.Open();
            connection.EnableExtensions(true);
            try
            {
                connection.LoadExtension("BrokenAppNative.dll", "empty_extension_this_should_fail");
            }
            catch (SQLiteException)
            {
                // should throw sqlite exception as its an empty library
            }

            new MainWindow().Show();
        }
    }
}
