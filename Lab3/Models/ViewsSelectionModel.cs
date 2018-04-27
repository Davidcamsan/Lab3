using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Lab3.Models
{
    public class ViewsSelectionModel
    {
        public ViewsSelectionModel()
        {
            lstViews = new List<ViewsSelectionModel>();
        }

        public int ID { get; set; }
        public string ViewPag { get; set; }

        public List<ViewsSelectionModel> lstViews { get; set; }

        public static async Task<ObservableCollection<ViewsSelectionModel>> ObtenerViews()
        {
            ObservableCollection<ViewsSelectionModel> lstViews1 = new ObservableCollection<ViewsSelectionModel>();
            lstViews1.Add(new ViewsSelectionModel { ID = 1, ViewPag = "MAPA" });
            lstViews1.Add(new ViewsSelectionModel { ID = 2, ViewPag = "Recordar" });
            lstViews1.Add(new ViewsSelectionModel { ID = 3, ViewPag = "Lista Nombres" });

            Task.Delay(1000);

            return lstViews1;
        }

    }
}
