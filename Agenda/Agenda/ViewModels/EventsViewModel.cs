using Agenda.Common.Models;
using Agenda.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace Agenda.ViewModels
{
    public class EventsViewModel : BaseViewModel
    {

        private ApiService apiService;

        private ObservableCollection<Eventos> events;

        public  ObservableCollection<Eventos> Events {
            get { return this.events; }
            set { this.SetValue(ref this.events, value); }
        }
        public EventsViewModel()
        {
            this.apiService = new ApiService();
            this.LoadEventos();
        }

        private async void LoadEventos()
        {
            var response = await this.apiService.GetList<Eventos>("http://localhost:53008", "/api", "/Eventos");
            if (!response.IsSuccess)
            {
                await App.Current.MainPage.DisplayAlert("Error", response.Message, "Accept");
                return;
            }

            var list = (List<Eventos>)response.Result;
            this.Events = new ObservableCollection<Eventos>(list);
        }
    }
}
