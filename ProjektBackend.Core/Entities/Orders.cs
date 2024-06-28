using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjektBackend.Shared.Models;

namespace ProjektBackend.Core.Entities
{
    public class Orders
    {
        [Key]
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public string? UserId { get; set; }
        public ApplicationUser? User { get; set; }
        public string? ClientId { get; set; }
        public Clients? Client { get; set; }
        public int CarId { get; set; }
        public Cars? Car { get; set; }
        public DateTime? PickupDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
