using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Storage;
using System.Diagnostics;
using Cocina.Model;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Collections.ObjectModel;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Cocina
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        enum CargaRecetas: int { exito=1, errorLecturaRecetas=0, errorSinRecetas=-1 };
        private ObservableCollection<Receta> Recetas;

        public MainPage()
        {
            Recetas = new ObservableCollection<Receta>();
            cargarRecetas();
            this.InitializeComponent();
        }

        private async void cargarRecetas()
        {
            ManejadorRecetas miManejadorRecetas = new ManejadorRecetas();
            int esPosibleLeerRecetas = await miManejadorRecetas.leerRecetas();
            switch (esPosibleLeerRecetas)
            {
                case (int)CargaRecetas.exito:
                    foreach (Receta receta in miManejadorRecetas.getRecetas())
                    {
                        string ubicacion = receta.direccionImagenReceta;
                        receta.direccionImagenReceta = String.Format("ms-appx:///Assets/{0}",ubicacion);
                        Recetas.Add(receta);
                    }
                    break;
                case (int)CargaRecetas.errorLecturaRecetas:
                    errorCargaTextblock.Text = "Hubo un error al cargar las recetas.";
                    break;
                case (int)CargaRecetas.errorSinRecetas:
                    errorCargaTextblock.Text = "No existen recetas disponibles para mostrar.";
                    break;
                default:
                    break;
            }

        }

        private void botonMenuHamburguesa_Click(object sender, RoutedEventArgs e)
        {
            menuHamburguesa.IsPaneOpen = !menuHamburguesa.IsPaneOpen;
        }


        private void GridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            
        }
    }
}
