using Ham.Models;
using System.ComponentModel.DataAnnotations;

namespace Ham.Lib.Models
{
    public class CallSign
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }

        public int TypeID { get; set; }
        public virtual Type Type { get; set; }
    }
}
