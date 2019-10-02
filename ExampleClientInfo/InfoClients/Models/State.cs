using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InfoClients.Models
{
    public class State
    {
        public int StateId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
                
        [DisplayName("Code state"), MaxLength(5)]
        public string Code { get; set; }

        [DisplayName("Country name")]
        public int CountryId { get; set; }
        
        //Relaciones
        public virtual Country Country { get; set; }
        public virtual ICollection<City> Cities { get; set; }
        public virtual ICollection<Client> Clients { get; set; }
    }
}
