using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace Cocina.Model
{
    class ManejadorRecetas
    {
        List<Receta> recetas;
        public ManejadorRecetas()
        {
            recetas = new List<Receta>();
        }

        public List<Receta> getRecetas()
        {
            return recetas;
        }

        private static async Task<string> leerJson(string nombreArchivo)
        {
            string ubicacionArchivo = "ms-appx:///Model/";
            string cadenaJson = "";
            try
            {
                Windows.Storage.StorageFile archivoReceta = await StorageFile.GetFileFromApplicationUriAsync(new Uri(ubicacionArchivo + nombreArchivo));
                await archivoReceta.OpenStreamForReadAsync();
                var archivoAbierto = await archivoReceta.OpenReadAsync();
                var archivoParaLectura = archivoAbierto.AsStreamForRead();
                var streamReader = new StreamReader(archivoParaLectura);
                cadenaJson = streamReader.ReadToEnd();
            }
            catch (ArgumentNullException)
            {
                cadenaJson = "";
            }
            return cadenaJson;
        }

        public async Task<int> leerRecetas()
        {
            string cadenaJson = await leerJson("Receta1.txt");
            if (!String.IsNullOrEmpty(cadenaJson))
            {
                try
                {
                    var serializador = new DataContractJsonSerializer(typeof(RootObject));
                    var streamMemoria = new MemoryStream(Encoding.UTF8.GetBytes(cadenaJson));
                    var informacion = (RootObject)serializador.ReadObject(streamMemoria);
                    RootObject receta = informacion;
                    Receta miReceta = receta.Receta;
                    recetas.Add(miReceta);
                    return 1;
                }
                catch (ArgumentNullException)
                {
                    return -1;
                }
            }
            else
            {
                return 0;
            }
        }

    }
}
