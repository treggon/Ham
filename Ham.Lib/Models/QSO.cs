using System.ComponentModel.DataAnnotations;

namespace Ham.Lib.Models
{
    public class QSO
    {
        [Key]
        public int ID { get; set; }
        public string Note { get; set; }

        [Display(Name = "Contact")]
        public int? ContactID { get; set; }
        public virtual Contact Contact { get; set; }

        [Display(Name = "Frequency")]
        public int? FrequencyID { get; set; }
        public virtual Frequency Frequency { get; set; }

    }
}
