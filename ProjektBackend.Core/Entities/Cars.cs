using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektBackendLab.Core.Entities
{
    public class Cars
    {
        [Key]
        public int CarId { get; set; }
        public string? Brand { get; set; }
        public string? Model { get; set; }

        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public Categories? Category { get; set; }
        public ICollection<Orders>? Orders { get; set; }
    }
}
