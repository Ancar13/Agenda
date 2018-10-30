using System.Data.Entity;

namespace Agenda.Domain.Models
{
    public class DataContext : DbContext
    {

        public DataContext() : base("DefaultConnection")
        {



        }
    }
}
