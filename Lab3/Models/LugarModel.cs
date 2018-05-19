using System;
using Xamarin.Forms.Maps;
using Realms;
namespace Lab3.Models
{
    public class LugarModel : RealmObject
    {
        public LugarModel()
        {
        }

        public int Latitud { get; set; }
        public int Longitud { get; set; }
        public string NombreSitio { get; set; }
        public string Descripcion { get; set; }
    }
}
