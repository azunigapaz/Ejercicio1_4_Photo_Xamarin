using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Ejercicio1_3App.Controllers;
using Ejercicio1_3App.Models;
using Plugin.Media;
using System.IO;

namespace Ejercicio1_3App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageCrearPersonas : ContentPage
    {
        public PageCrearPersonas()
        {
            InitializeComponent();
        }

        byte[] imageToSave;

        private async void btnagregar_Clicked(object sender, EventArgs e)
        {
            var persona = new Personas
            {
                nombres = nombre.Text,
                apellidos = apellido.Text,
                edad = Convert.ToInt32(edad.Text),
                correo = correo.Text,
                direccion = direccion.Text,
                imagen = imageToSave
            };

            var resultado = await App.BaseDatos.PersonaGuardar(persona);

            if (resultado != 0)
            {
                await DisplayAlert("Aviso", "Persona Ingresada con Exito!!!", "Ok");
            }
            else
            {
                await DisplayAlert("Aviso", "Ha Ocurrido un Error", "Ok");
            }

            await Navigation.PopAsync();
        }

        private async void btntakephoto_Clicked(object sender, EventArgs e)
        {
            var takepic = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                Directory = "PhotoApp",
                Name = DateTime.Now.ToString() + "_Pic.jpg",
                SaveToAlbum = true
            });

            await DisplayAlert("Ubicacion de la foto: ", takepic.Path, "Ok");

            if(takepic != null)
            {
                imageToSave = null;
                MemoryStream memoryStream = new MemoryStream();

                takepic.GetStream().CopyTo(memoryStream);
                imageToSave = memoryStream.ToArray();

                img.Source = ImageSource.FromStream(() => { return takepic.GetStream(); });                
            }

        }

        private byte[] GetImageBytes(Stream stream)
        {
            byte[] ImageBytes;
            using (var memoryStream = new System.IO.MemoryStream())
            {
                stream.CopyTo(memoryStream);
                ImageBytes = memoryStream.ToArray();
            }
            return ImageBytes;
        }

    }
}