using System.ComponentModel.DataAnnotations;

namespace Ham.Lib.Models
{
    public class Type
    {
        [Key]
        public int ID { get; set; }
        public int Name { get; set; }

    }
}
