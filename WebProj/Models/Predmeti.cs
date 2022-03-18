using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Models
{
    public class Predmet
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [MaxLength(50)]
        public string Naziv { get; set; }

        [Required]
        [MaxLength(20)]
        public string Tip { get; set; }


        [Required]
        [MaxLength(4)]
        public int Godina { get; set; }

        [Required]
        [MaxLength(5)]
        public string Era { get; set; }

        [MaxLength(50)]
        public string Tvorac { get; set; }
       
        [JsonIgnore] 
        public virtual Muzej Muzej { get; set; }

    
    }
}