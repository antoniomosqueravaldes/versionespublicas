using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InfoClients.Models
{
    public class Country
    {
        public int CountryId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [DisplayName("Code country"), MaxLength(5)]
        public string Code { get; set; }


        // Relaciones
        public virtual ICollection<State> States { get; set; }
        public virtual ICollection<Client> Clients { get; set; }
    }
}
