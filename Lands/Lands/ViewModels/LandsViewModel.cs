using Lands.Models;
using Lands.Services;
using System.Collections.ObjectModel;

namespace Lands.ViewModels
{
    public class LandsViewModel : BaseViewModel
    {
        /*Para poder pintar la lista de paises se debe hacer mediante una 
         * ObservableColletion que no es mas que un objeto List*/

        #region Services
        private ApiService apiService;
        #endregion

        #region Atributes
        private ObservableCollection<Land> lands;
        #endregion

        #region Properties
        public ObservableCollection<Land> Lands
        {
            get { return this.lands; }
            set { SetValue(ref this.lands, value); }
        }

        #endregion

        #region Constructors 
        public LandsViewModel()
        {
            this.LoadLands();
            apiService = new ApiService();
        }
        #endregion

        #region Methods
        private async void LoadLands()
        {
                       
        }
        #endregion



    }
}
