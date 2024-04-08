using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkorianzLap.Data.Models.Shop
{
    public class OrderLine
    {
        [Key]
        public long OrderLineId { get; set; }

        [Required]
        public Order Order { get; set; }

        [Required]
        public Product Product { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}
