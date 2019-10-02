using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InfoClients.Models
{
    public class Visit
    {
        public int VisitId { get; set; }

        [Required]        
        public DateTime Date { get; set; }

        [Required, DisplayName("Select client"), ReadOnly(true)]
        public int ClientId { get; set; }

        [Required, DisplayName("Sales Representative")]
        public int SalesRepresentativeId { get; set; }

        [Required]
        public int Net { get; set; }

        [DisplayName("Visit total"), ReadOnly(true), Description("Net * Visits Percentage")]
        public int VisitTotal { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        //Relaciones
        public virtual SalesRepresentative SalesRepresentative { get; set; }
        public virtual Client Client { get; set; }
    }
}
