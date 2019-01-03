using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Lands.Views;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Lands
{
    public partial class App : Application
    {
        //Aqui todas las apps vienen predetermindas para que arranquen por la MainPage
        //Pero podermos cambiarla en esta caso la colocamos a iniciar por una NavegationPage
        //La cual nos sirve para poder invocar otras paginas.

        #region Constructors
        public App()
        {
            InitializeComponent();

            this.MainPage = new NavigationPage(new LoginPage());
        }
        #endregion


        #region Methods
        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        #endregion
    }
}
