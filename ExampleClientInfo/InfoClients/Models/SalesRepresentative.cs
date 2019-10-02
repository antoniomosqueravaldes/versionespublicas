using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InfoClients.Models
{
    public class SalesRepresentative
    {
        public int SalesRepresentativeId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Fullname { get; set; }

        [DisplayName("Employe code"), MaxLength(15), Required]
        public string Employecode { get; set; }

        //Relaciones
        public virtual ICollection<Visit> Visits { get; set; }
    }
}
