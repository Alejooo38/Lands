using System;
using System.Collections.Generic;
using System.Text;

namespace Lands.ViewModels
{
    /* La MainViewModel es la clase más importante es la que gobierna las demas clases, 
     * inicialmente esta clase se debe enlazar con una clase que llamaremos InstanceLocator */

    /* Aqui es donde se referencia la LoginViewModel con la variable Login como
     * es la pagina inicial toca instanciar el Login para que arranque por aca
     y este a su vez se Binda en la LoginPage con el comando Binding Login*/

    public class MainViewModel
    {
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

        #endregion

        #region Constructors
        public MainViewModel()
            {
                this.Login = new LoginViewModel();
                instance = this;
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
    }
}
