using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkorianzLap.Data.Models.Shop
{
    public class Product
    {
        [Key]
        public long? Id { get; set; }

        [Required]
        public bool IsEquipment { get; set; } = false;

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [StringLength(255)]
        public string ShortDescription { get; set; }

        [Required]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Price { get; set; }

        [Required]
        public int HasStock { get; set; }

        [Required]
        public int Stock { get; set; }

        [Required]
        public bool IsOldRevision { get; set; } = false;

        [Required]
        public bool IsActive { get; set; } = true;

        [Required]
        public bool IsDeleted { get; set; } = false;
    }
}
