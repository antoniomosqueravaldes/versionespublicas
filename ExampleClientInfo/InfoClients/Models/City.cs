using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InfoClients.Models
{
    public class City
    {
        public int CityId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(5), DisplayName("Code city")]
        public string Code { get; set; }

        [DisplayName("State name")]
        public int StateId { get; set; }

        // Relaciones
        public virtual State States { get; set; }
        public virtual ICollection<Client> Clients { get; set; }
    }
}
