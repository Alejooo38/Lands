﻿using GalaSoft.MvvmLight.Command;
using Lands.Models;
using Lands.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

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
        private ObservableCollection<LandItemViewModel> lands;
        private bool isRefresing;
        private string filter;        
        #endregion

        #region Properties
        public ObservableCollection<LandItemViewModel> Lands
        {
            get { return this.lands; }
            set { SetValue(ref this.lands, value); }
        }

        public bool IsRefresing
        {
            get { return this.isRefresing; }
            set { SetValue(ref this.isRefresing, value); }
        }

        public string Filter
        {
            get { return this.filter; }
            set
            {
                SetValue(ref this.filter, value);
                this.Search();
            }
        }

        #endregion

        #region Constructors 
        public LandsViewModel()
        {
            this.apiService = new ApiService();
            this.LoadLands();          
        }
        #endregion

        #region Methods

 /* Este metodo sirve para consumir el Webservice y traer los datos en una lista
  primero consumimos el metodo GetList del apiService, luego pintamos el listado
  de los paises en un list*/

        private async void LoadLands()
        {
            this.IsRefresing = true;
            var connection = await this.apiService.CheckConnection();

            if (!connection.IsSuccess)
            {
                this.IsRefresing = false;
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    connection.Message,
                    "Accept");
                await Application.Current.MainPage.Navigation.PopAsync();
                return;
            }

            var response = await this.apiService.GetList<Land>(
                "http://restcountries.eu",
                "/rest",
                "/v2/all");

            if (!response.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    response.Message,
                    "Accept");
                await Application.Current.MainPage.Navigation.PopAsync();
                return;
            }

            MainViewModel.GetInstance().LandsList = (List<Land>)response.Result;
            this.Lands = new ObservableCollection<LandItemViewModel>(
                this.ToLandItemViewModel());
            this.IsRefresing = false;
        }
        #endregion

        #region Methods
        private IEnumerable<LandItemViewModel> ToLandItemViewModel()
        {
            return MainViewModel.GetInstance().LandsList.Select(l => new LandItemViewModel
            {
                Alpha2Code = l.Alpha2Code,
                Alpha3Code = l.Alpha3Code,
                AltSpellings = l.AltSpellings,
                Area = l.Area,
                Borders = l.Borders,
                CallingCodes = l.CallingCodes,
                Capital = l.Capital,
                Cioc = l.Cioc,
                Currencies = l.Currencies,
                Demonym = l.Demonym,
                Flag = l.Flag,
                Gini = l.Gini,
                Languages = l.Languages,
                Latlng = l.Latlng,
                Name = l.Name,
                NativeName = l.NativeName,
                NumericCode = l.NumericCode,
                Population = l.Population,
                Region = l.Region,
                RegionalBlocs = l.RegionalBlocs,
                Subregion = l.Subregion,
                Timezones = l.Timezones,
                TopLevelDomain = l.TopLevelDomain,
                Translations = l.Translations,
            });
        }
        #endregion


        #region Commands

        public ICommand SearchCommand
        {
            get
            {
                return new RelayCommand(Search);
            }
        }

        /*En este metodo Search se hace la busqueda, para esto usamos Linq, donde
         * hacemos un select de lo que queremos mostrar*/
    
        private void Search()
        {
            if (string.IsNullOrEmpty(this.Filter))
            {
                this.Lands = new ObservableCollection<LandItemViewModel>
                    (this.ToLandItemViewModel());
            }
            else
            {
                this.Lands = new ObservableCollection<LandItemViewModel>
                    (this.ToLandItemViewModel()
                    .Where(l => l.Name.ToLower().Contains(this.Filter.ToLower()) ||
                                l.Capital.ToLower().Contains(this.Filter.ToLower())));
            }
        }
        #endregion



    }
}
