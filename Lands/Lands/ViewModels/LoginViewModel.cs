using GalaSoft.MvvmLight.Command;
using Lands.Helpers;
using Lands.Views;
using Rg.Plugins.Popup.Services;
using System;
using System.Windows.Input;
using Xamarin.Forms;

/* Cada vez que se crea una Page se debe generar una ViewModel ejemplo, se
 * se creo la LoginPage se debe crear una LoginviewModel la cual se debe ligar 
 con la MainViewModel*/

namespace Lands.ViewModels
{

/* Aqui se crea las propiedades que se hacen en la loginPage, las propiedades 
   deben ser del tipo que la declaramos*/

    public class LoginViewModel : BaseViewModel
    {

/* Para poder refrescar los atributos de Email, Password, IsRunning, IsEnable, 
    tenemos que crear unos atributos privados estos se crean iniciando 
    con minuscula a diferencia de las propiedades esta se hereda de la BaseViewModel*/

        #region Attributes
        private string email;
        private string password;
        private Boolean isRunning;
        private Boolean isEnable;
        #endregion

        #region Properties
        public string Email
        {
            get { return email; }
            set { SetValue(ref email, value); }
        }

        public string Password
        {
            get { return password; }
            set { SetValue(ref password, value); }
        }

        public bool IsRunning
        {
            get { return this.isRunning; }
            set { SetValue(ref isRunning, value); }
        }

        public bool IsRemembered
        {
            get;
            set;
        }

        public bool IsEnable
        {
            get { return this.isEnable; }
            set { SetValue(ref isEnable, value); }
        }
        #endregion

        /* Los botones por defecto inician en true por ende toca 
         * inicializarlos en el constructor */

        #region Constructors
        public LoginViewModel()
        {
            this.IsRemembered = true;
            this.IsEnable = true;

            this.Email = "druizbermud@uniminuto.edu.co";
            this.Password = "123";
        }
        #endregion

        /* Para poder usar el RelayCommand toca usar un Nuget que se llama 
         * MvvmLightLibs*/

        #region Commands
        public ICommand LoginCommand
        {
            get
            {
                return new RelayCommand(Login);
            }
        }

        /* Cuando generamos el metodo para el Login validamos que el usuario haya 
                ingresado Email y password*/

        /* Para convertir un metodo en asyncrono basta solo con utilizar la palabra
         async con esto ya podemos usar el commando await el cual sirve para pintar 
         mensajes el cual se pinta con el return*/

        private async void Login()
        {
            if (string.IsNullOrEmpty(this.Email))
            {
                await Application.Current.MainPage.DisplayAlert(
                    Languages.Error,
                    Languages.EmailValidation,
                    Languages.Accept);
                return;
            }

            if (string.IsNullOrEmpty(this.Password))
            {
                await Application.Current.MainPage.DisplayAlert(
                    Languages.Error,
                    Languages.PasswordValidation,
                    Languages.Accept);
                this.Password = string.Empty;
                return;
            }

            this.IsRunning = true;
            this.IsEnable = false;

            var loadingPage = new CustomGIFLoader();
            await PopupNavigation.PushAsync(loadingPage);


            if (this.Email != "druizbermud@uniminuto.edu.co" ||
               this.Password != "123")
            {
                this.IsRunning = false;
                this.IsEnable = true;

                await Application.Current.MainPage.DisplayAlert(
                    Languages.Error,
                    Languages.SomethingWrong,
                    Languages.Accept);
                return;
            }

            this.IsRunning = false;
            this.IsEnable = true;

            this.Email = string.Empty;
            this.Password = string.Empty;

            //Con esta linea apagamos el ActivityIndicator
            await PopupNavigation.RemovePageAsync(loadingPage);

            //Aqui invocamos la LandsPage, pero antes debemos instanciar la ViewModel 
            //que esta en la MainviewModel por lo cual creamos el patron Singleton
            //para luego usarlo aca con lo que garantizamos que antes de pintar la 
            //lands page estamos estableciendo la landsViewModel 

            MainViewModel.GetInstance().Lands = new LandsViewModel();

            /*Esta linea era antes de colocar el Munu, ahora ya no hacemos Push sino 
             * cerrar la sesion otra forma de navegar es cambiando la MainPage
             * await Application.Current.MainPage.Navigation.PushAsync(
                  new LandsPage());*/

            Application.Current.MainPage = new MasterPage();
            
        }

        //await PopupNavigation.RemovePageAsync(loadingPage);
        #endregion
    }
}
