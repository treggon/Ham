using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Ham.Lib.Models
{
    public class CallSign
    {
        [Key]
        public int ID { get; set; }
        [Display(Name = "Call Sign")]
        public string Name { get; set; }

        [Display(Name = "Category")]
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }
    }
}
