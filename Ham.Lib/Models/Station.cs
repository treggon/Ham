using System.ComponentModel.DataAnnotations;

namespace Ham.Lib.Models
{
    public class Station
    {
        [Key]
        public int ID { get; set; }
        public string Note { get; set; }
        public string Power { get; set; }

        public int? CallSignID { get; set; }
        public virtual CallSign CallSign { get; set; }

    }
}
