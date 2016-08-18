using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Cocina;
using Windows.UI.Xaml.Media.Imaging;
using System.Runtime.Serialization;

namespace Cocina.Model
{
    [DataContract]
    public class IngredienteItem
    {
        [DataMember]
        public string ingrediente { get; set; }

        [DataMember]
        public int cantidad { get; set; }
    }

    [DataContract]
    public class ListaIngredientes
    {
        [DataMember]
        public List<IngredienteItem> ingredienteItem { get; set; }
    }

    [DataContract]
    public class CategoriaItem
    {
        [DataMember]
        public string categoria { get; set; }
    }

    [DataContract]
    public class Categorias
    {
        [DataMember]
        public List<CategoriaItem> categoriaItem { get; set; }
    }

    [DataContract]
    public class Receta
    {
        [DataMember]
        public string nombreReceta { get; set; }

        [DataMember]
        public ListaIngredientes listaIngredientes { get; set; }

        [DataMember]
        public int tiempoPreparacion { get; set; }

        [DataMember]
        public int porciones { get; set; }

        [DataMember]
        public int dificultad { get; set; }

        [DataMember]
        public Categorias categorias { get; set; }

        [DataMember]
        public string direccionImagenReceta { get; set; }

    }

    [DataContract]
    public class RootObject
    {
        [DataMember]
        public Receta Receta { get; set; }
    }
}
