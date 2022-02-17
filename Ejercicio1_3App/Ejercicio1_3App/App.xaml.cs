using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Ejercicio1_3App.Controllers;
using System.IO;

namespace Ejercicio1_3App
{
    public partial class App : Application
    {      
        
        static PersonasDB basedatos;

        public static PersonasDB BaseDatos
        {
            get
            {
                if(basedatos == null)
                {
                    basedatos = new PersonasDB(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "PersonasDB.db3"));
                }
                return basedatos;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Views.PersonasPage());
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
