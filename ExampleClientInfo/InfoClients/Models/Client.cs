using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InfoClients.Models
{
    public class Client
    {
        public int ClientId { get; set; }

      //  [Required, MaxLength(20), Description("It must be stored encrypted")]
        public string Nit { get; set; }  //Pendiente encryp, desencryp ColumnBD

       // [MaxLength(100), Required, DisplayName("Full name")]
        public string Fullname { get; set; }        
        
        public string Address { get; set; }

       // [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        public int CountryId { get; set; }
        public int StateId { get; set; }
        
        
        public int CityId { get; set; }

//        [MaxLength(4), DisplayName("Credit Limit"), Description("Maximum amount assigned for visits")]
        public int CreditLimit { get; set; }        

        //[MaxLength(4), Required(AllowEmptyStrings =true),ReadOnly(true),DisplayName("Available Credit"), Description("Each time a visit is registered, you must lower it, subtracting the Visit total from the visit registered.")]
        public int AvailableCredit { get; set; }

       // [DisplayName("Visits Percentage"), Range(0,100), ReadOnly(true), Required(AllowEmptyStrings = true)]
        public int VisitsPercentage { get; set; }


        // Relaciones
        public virtual Country Country { get; set; }
        public virtual State State { get; set; }
        public virtual City City { get; set; }
        public virtual ICollection<Visit> Visits { get; set; }
    }
}
