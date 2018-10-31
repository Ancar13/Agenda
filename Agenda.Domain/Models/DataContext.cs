using System.Data.Entity;

namespace Agenda.Domain.Models
{
    public class DataContext : DbContext
    {

        public DataContext() : base("DefaultConnection")
        {



        }

        public System.Data.Entity.DbSet<Agenda.Common.Models.Eventos> Eventos { get; set; }
    }
}
