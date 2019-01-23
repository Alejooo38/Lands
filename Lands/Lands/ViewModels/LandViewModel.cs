using Lands.Models;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace Lands.ViewModels
{
    public class LandViewModel : BaseViewModel
    {
        /*Para pintar los Borders toca hacerlo mediante una Observablecolletion 
         mediante la propiedad Borders la cual se debe Bindar en BordersPage
         con un ItemSource en razon a que vienen en un objeto list string*/

        #region Attributes
        private ObservableCollection<Border> borders;
        private ObservableCollection<Currency> currencies;
        private ObservableCollection<Language> languages;
        #endregion
        #region Properties
        public Land Land
        {
            get;
            set;
        }

        public ObservableCollection<Border> Borders
        {
            get { return this.borders; }
            set { SetValue(ref this.borders, value); }
        }

        public ObservableCollection<Currency> Currencies
        {
            get { return this.currencies; }
            set { SetValue(ref this.currencies, value); }
        }

        public ObservableCollection<Language> Languages
        {
            get { return this.languages; }
            set { SetValue(ref this.languages, value); }
        }
        #endregion

        #region Constructors
        public LandViewModel(Land land)
        {
            this.Land = land;
            this.loadBorders();
            this.Currencies = new ObservableCollection<Currency>(this.Land.Currencies);
            this.Languages = new ObservableCollection<Language>(this.Land.Languages);
        }

        #region Methods
        private void loadBorders()
        {
            this.Borders = new ObservableCollection<Border>();
            foreach (var border in this.Land.Borders)
            {
                var land = MainViewModel.GetInstance().LandsList.Where(
                    l => l.Alpha3Code == border).FirstOrDefault();
                if (land != null)
                {
                    this.borders.Add(new Border
                    {
                        Code = land.Alpha3Code,
                        Name = land.Name,
                    });
                }
            }
        } 
        #endregion
        #endregion
    }
}
