using Lands.Helpers;
using Lands.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Lands.ViewModels
{
    /* La MainViewModel es la clase más importante es la que gobierna las demas clases, 
     * inicialmente esta clase se debe enlazar con una clase que llamaremos InstanceLocator */

    /* Aqui es donde se referencia la LoginViewModel con la variable Login como
     * es la pagina inicial toca instanciar el Login para que arranque por aca
     y este a su vez se Binda en la LoginPage con el comando Binding Login*/

    public class MainViewModel
    {
        #region Properties
        public List<Land> LandsList
        {
            get;
            set;
        }

        public ObservableCollection<MenuItemViewModel> Menus
        {
            get;
            set;
        }
        #endregion

        #region ViewModel
        public LoginViewModel Login
            {
                get;
                set;
            }

        public LandsViewModel Lands
        {
            get;
            set;
        }

        public LandViewModel Land
        {
            get;
            set;
        }
        #endregion

        #region Constructors
        public MainViewModel()
            {
                instance = this;
                this.Login = new LoginViewModel();                
                this.LoadMenu();
            }
        #endregion

        #region Singleton 
        private static MainViewModel instance;

        public static MainViewModel GetInstance()
        {
            if (instance == null)
            {
                return new MainViewModel();
            }
            return instance;
        }
        #endregion

        #region Methods
        private void LoadMenu()
        {
            this.Menus = new ObservableCollection<MenuItemViewModel>();

            this.Menus.Add(new MenuItemViewModel
            {
                Icon = "ic_settings",
                PageName = "MyProfilePage",
                Title = Languages.MyProfile,
            });            

            this.Menus.Add(new MenuItemViewModel
            {
                Icon = "ic_insert_chart",
                PageName = "StatisticsPage",
                Title = Languages.Statistics,
            });

            this.Menus.Add(new MenuItemViewModel
            {
                Icon = "ic_exit_to_app",
                PageName = "LoginPage",
                Title = Languages.LogOut,
            });
        }
        #endregion

    }
}
