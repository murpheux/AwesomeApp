using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AwesomeApp.Data;

namespace AwesomeApp
{
    public partial class App : Application
    {
        static StudentDatabase database;

        // Create the database connection as a singleton.
        public static StudentDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new StudentDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Notes.db3"));
                }
                return database;
            }
        }

        public App ()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }

        protected override void OnStart ()
        {
        }

        protected override void OnSleep ()
        {
        }

        protected override void OnResume ()
        {
        }
    }
}

