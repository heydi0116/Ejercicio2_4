using LibVLCSharp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ejercicio2_4
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class mostrar : ContentPage
    {
        LibVLC _libvlc;

        public mostrar()
        {
            InitializeComponent();
   
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            ListaEmpleados.ItemsSource = await App.BaseDatos.listaempleados();
        }

       private void ListaEmpleados_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var resul = e.SelectedItem as Modelos.Datos;
            Core.Initialize();
            _libvlc = new LibVLC();
            MediaPlayer _mediaPlayer = new MediaPlayer(_libvlc)
            {
                Media = new Media(_libvlc, new Uri(resul.direccion))
            };

            myVideo.MediaPlayer = _mediaPlayer;

            myVideo.MediaPlayer.Play();


        }
    }
}