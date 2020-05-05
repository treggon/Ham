using System.ComponentModel.DataAnnotations;

namespace Ham.Lib.Models
{
    public class Contact
    {
        [Key]
        public int ID { get; set; }
        public string   Name { get; set; }

        [Display(Name = "Call Sign")]
        public int? CallSignID { get; set; }
        public virtual CallSign CallSign { get; set; }

    }
}