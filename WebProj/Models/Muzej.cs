using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;
using System.Text.Json.Serialization;

namespace Models{


    public class Muzej{

        [Key]
        public int ID { get; set; }

        [Required]
        public string Naziv { get; set; }

        [JsonIgnore] 
        public virtual List<Predmet> Predmeti { get; set; }
        public virtual List<Karta> Karte { get; set; }
    
    }
}
