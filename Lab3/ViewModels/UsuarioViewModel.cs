using System;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;
using System.Linq;
using Lab3.Models;
using Lab3.Views;

namespace Lab3.ViewModels
{
    public class UsuarioViewModel : INotifyPropertyChanged
    {
        #region Singleton
        private static UsuarioViewModel Instance = null;

        public UsuarioViewModel()
        {
            InitClass();
            InitCommands();
        }


        public static UsuarioViewModel GetInstance()
        {
            if (Instance == null)
                Instance = new UsuarioViewModel();

            return Instance;
        }

        public static void DeleteInstance()
        {
            if (Instance != null)
                Instance = null;
        }
        #endregion




        #region Instances
        //LISTA DE USUARIOS
        private ObservableCollection<UsuarioModel> _lstUsuarios = new ObservableCollection<UsuarioModel>();

        private string _InputEmail = "";
        public string InputEmail
        {
            get { return _InputEmail; }
            set { _InputEmail = value; }
        }

        private string _InputPassword = "";
        public string InputPassword
        {
            get { return _InputPassword; }
            set { _InputPassword = value; }
        }


        public ObservableCollection<UsuarioModel> lstUsuarios
        {
            get { return _lstUsuarios; }
            set
            { 
                _lstUsuarios = value;
                OnPropertyChanged("lstUsuarios");
            }
        }

        //USUARIO ESCOGIDO
        private UsuarioModel _UsuarioActual { get; set; }

        public UsuarioModel UsuarioActual
        {
            get { return _UsuarioActual; }

            set
            {
                _UsuarioActual = value;
                OnPropertyChanged("UsuarioActual");
            }

        }

        public ObservableCollection<LugarModel> lstLocations = new ObservableCollection<LugarModel>();

        //LUGAR ESCOGIDO DEL USUARIO ESCOGIDO
        private LugarModel _LugarActual = new LugarModel();
        public LugarModel LugarActual
        {
            get { return _LugarActual; }
            set
            {
                _LugarActual = value;
                OnPropertyChanged("LugarActual");
            }
        }

        public ObservableCollection<ViewsSelectionModel> lstView { get; set; } 


        #endregion


        #region ICommands

        public ICommand AuthenticateUserCommand { get; set; }
        public ICommand EnterNewLugarCommand { get; set; }
        public ICommand GoSelectedPageCommand { get; set; }
        public ICommand SignUpPageCommand { get; set; }
        public ICommand SignUpSaveCommand { get; set; }
        #endregion


        #region Methods

        private void AuthenticateUser()
        {
            UsuarioActual = lstUsuarios.Where(x => x.Email == InputEmail && x.Password == InputPassword).FirstOrDefault();
            if(UsuarioActual.Email != null)
            {
                App.Current.MainPage = new MasterDetailPage
                {
                    Master = new MenuView(),
                    Detail = new NavigationPage(new FormularioView())
                };

            }
 
        }

        private void EnterNewLugar()
        {
            UsuarioActual.lstLugares.Add(LugarActual);
            LugarActual = new LugarModel();
            OnPropertyChanged("UsuarioActual");
        }

        private void GoSelectedPage(int ID){
            if (ID == 1)
            {
                ((MasterDetailPage)App.Current.MainPage).Detail.Navigation.PushAsync(new MapaView());
            }
            else if(ID == 2)
            {
                ((MasterDetailPage)App.Current.MainPage).Detail.Navigation.PushAsync(new RecordarView());
            }
            else if (ID ==3)
            {
                ((MasterDetailPage)App.Current.MainPage).Detail.Navigation.PushAsync(new NombresLugaresView());

            }
        }


        private void SignUpPage()
        {
            App.Current.MainPage= new SignUpView();
        }


        private void SignUpSave()
        {
            UsuarioModel.SalvarUsuario(UsuarioActual);
            App.Current.MainPage = new LogInView();

        }
        #endregion

        private async void InitClass()
        {
            lstUsuarios = await UsuarioModel.ObtenerUsuarios();
            lstView = await ViewsSelectionModel.ObtenerViews();
        }

        private void InitCommands()
        {
            AuthenticateUserCommand = new Command(AuthenticateUser);
            EnterNewLugarCommand = new Command(EnterNewLugar);
            GoSelectedPageCommand = new Command<int>(GoSelectedPage);
            SignUpPageCommand = new Command(SignUpPage);
            SignUpSaveCommand = new Command(SignUpSave);
        }


        #region INotifyPropertyChanged Interface
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion



    }//END OF USUARIO_VIEW_MODEL_CLASS
}//END OF NAMESPACE
