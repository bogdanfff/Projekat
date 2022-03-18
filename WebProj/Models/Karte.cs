using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System;
using System.Text.Json.Serialization;

namespace Models
{
 public class Karta
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [MaxLength(50)]
        public string Ime { get; set; }

        [Required]
        [MaxLength(50)]
        public string Prezime { get; set; }

        [Required]
        [MaxLength(10)]
        public int BrojRezervacije { get; set; }
        
        [JsonIgnore] 
        public virtual Muzej Muzej { get; set; }
    }
}