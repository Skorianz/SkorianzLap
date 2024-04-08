using Microsoft.CodeAnalysis;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkorianzLap.Data.Models.Shop
{
    public class ProductEquipment
    {
        [ForeignKey("Products")]
        public long ProductId { get; set; }
        [NotMapped]
        public Product Product { get; set; }

        [ForeignKey("Products")]
        public long EquipmentProductId { get; set; }
        [NotMapped]
        public Product EquipmentProduct{ get; set; }
    }
}
