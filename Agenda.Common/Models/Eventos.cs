using System;
using System.ComponentModel.DataAnnotations;

namespace Agenda.Common.Models
{
    public class Eventos
    {
        [Key]
        public int id { get; set; }

        [Required]
        public string title { get; set; }

        [DataType(DataType.MultilineText)]
        public string descripcion { get; set; }
        public string color { get; set; }
        public string textColor { get; set; }
        public DateTime start { get; set; }
        public DateTime end { get; set; }

        //public override string ToString()
        //{
        //    return this.title;
        //}
    }
}
