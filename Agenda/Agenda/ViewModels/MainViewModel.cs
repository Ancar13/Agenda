
namespace Agenda.ViewModels
{
    public class MainViewModel
    {
        public EventsViewModel Events { get; set; }

        public MainViewModel() {
            this.Events = new EventsViewModel();
        }
    }
}
