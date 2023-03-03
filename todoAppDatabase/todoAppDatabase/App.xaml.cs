using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace todoAppDatabase
{
    public partial class App : Application
    {
        private static SQLiteHelper db;
        public static SQLiteHelper MyDatabase
        {
            get
            {
                db = null;
                if (db == null)
                {
                    db = new SQLiteHelper(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                        "MyStore.db3"));
                }
                return db;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage()); 
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
