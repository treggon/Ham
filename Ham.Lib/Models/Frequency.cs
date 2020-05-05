using System;
using System.ComponentModel.DataAnnotations;

namespace Ham.Lib.Models
{
    public class Frequency
    {
        public int ID { get; set; }
        [Display(Name = "Frequency (Hz)")]
        public Double Hz { get; set; }
        [Display(Name = "Common Name")]
        public string Name { get; set; }


    }
}
