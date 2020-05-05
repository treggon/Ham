using Ham.Lib.Models;
using System.ComponentModel.DataAnnotations;

namespace Ham.Models
{
    public class Contact
    {
        [Key]
        public int ID { get; set; }
        public string   Name { get; set; }
        public int? CallSignID { get; set; }
        public virtual CallSign CallSign { get; set; }

    }
}