using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Realms;


namespace Lab3.Models
{
    public class UsuarioModel : RealmObject
    {
        public UsuarioModel()
        {
            
        }

        public int ID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string NombreDePila { get; set; }
        public string Apellido { get; set; }
        public string Foto { get; set; }
        public bool SwitchedStatus { get; set; }
        public IList<LugarModel> lstLugares { get; }


        public static async Task<ObservableCollection<UsuarioModel>> ObtenerUsuarios()
        {
            ObservableCollection<UsuarioModel> lstUsuarios = new ObservableCollection<UsuarioModel>();

            lstUsuarios.Add(new UsuarioModel { ID = 1, Email = "Danieloduber", Password = "SanJose1", NombreDePila = "Daniel", Apellido = "Oduber", SwitchedStatus=false });
            lstUsuarios.Add(new UsuarioModel { ID = 2, Email = "Melissavalerio", Password = "Meli123", NombreDePila = "Melissa", Apellido = "Valerio", SwitchedStatus=false });

           Task.Delay(1000);

            return lstUsuarios;
        }

        public static void SalvarUsuario(UsuarioModel user){
            var realm = Realm.GetInstance();

            realm.Write(() =>
            {
                realm.Add(user);
            });
        }


    }
}
