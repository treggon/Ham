using System.ComponentModel.DataAnnotations;

namespace Ham.Lib.Models
{
    public class Category
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }


    }
}
