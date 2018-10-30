using Agenda.Domain.Models;

namespace Agenda.Backend.Models
{
    public class LocalDataContext : DataContext
    {
        public System.Data.Entity.DbSet<Agenda.Common.Models.Eventos> Eventos { get; set; }
    }
}