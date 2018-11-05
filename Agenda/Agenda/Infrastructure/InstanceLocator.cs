using Agenda.ViewModels;
namespace Agenda.Infrastructure
{
    public class InstanceLocator
    {
        public MainViewModel Main { get; set; }


        public InstanceLocator()
        {
            this.Main = new MainViewModel();
        }
    }
}
