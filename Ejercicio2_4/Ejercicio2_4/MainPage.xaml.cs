using Plugin.Media;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Ejercicio2_4.Modelos;

namespace Ejercicio2_4
{
    public partial class MainPage : ContentPage
    {
        string direccion_;

        public MainPage()
        {
            InitializeComponent();
        }

        async private void btnGrabar_Clicked(object sender, EventArgs e)
        {
            var takepic = await CrossMedia.Current.TakeVideoAsync(new Plugin.Media.Abstractions.StoreVideoOptions
            {
                Directory = "PhotoApp",
                Name = "video.mp4"
            });

            direccion_ = takepic.Path;
        }

        async private void btnGuardar_Clicked(object sender, EventArgs e)
        {
            var emple = new Datos
            {
                nombre = txtNombre.Text,
                direccion = direccion_
            };



            var resultado = await App.BaseDatos.EmpleadoGuardar(emple);
            if (resultado != 0)
            {
                await DisplayAlert("", "Registro Guardado!", "cerrar");
                txtNombre.Text = "";
            }

        }

        async private void btnLista_Clicked(object sender, EventArgs e)
        {
            var newpage = new mostrar();
            await Navigation.PushAsync(newpage);

        }
    }
}
