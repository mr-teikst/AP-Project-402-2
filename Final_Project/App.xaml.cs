using ApProject.Models;
using System.Configuration;
using System.Data;
using System.Windows;

namespace Final_Project
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Subscribe to the Exit event
            this.Exit += OnApplicationExit;

            // Subscribe to the SessionEnding event
            this.SessionEnding += OnSessionEnding;
        }

        private void OnApplicationExit(object sender, ExitEventArgs e)
        {
            // Call the function before exit
            CleanUpBeforeExit();
        }

        private void OnSessionEnding(object sender, SessionEndingCancelEventArgs e)
        {
            // Call the function before session ends
            CleanUpBeforeExit();
        }

        public void CleanUpBeforeExit()
        {
            // Your cleanup code here
            MessageBox.Show("Saving ...");
            User.SaveToJsonFile();
        }
    }
}

