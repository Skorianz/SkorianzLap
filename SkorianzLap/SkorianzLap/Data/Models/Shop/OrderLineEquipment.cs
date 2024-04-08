using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkorianzLap.Data.Models.Shop
{
    public class OrderLineEquipment
    {
        [ForeignKey("Orders")]
        public long OrderLineId { get; set; }
        [NotMapped]
        public OrderLine OrderLine { get; set; }

        [ForeignKey("Products")]
        public long EquipmentProductId { get; set; }
        [NotMapped]
        public Product EquipmentProduct { get; set; }

        public int Quantity { get; set; }
    }
}
