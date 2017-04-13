using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class Movie
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public String title { get; set; }
        [Required]
        public short time { get; set; }
        public short year { get; set; }
    }
}
