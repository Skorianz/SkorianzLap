using System.ComponentModel.DataAnnotations;

namespace SkorianzLap.Data.Models.Shop
{
    public class Order
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public ApplicationUser ApplicationUser { get; set; }

        [Required]
        public DateTime OrderCreationDate { get; set; }

        public DateTime? OrderCompletionDate { get; set; }

        public DateTime? PaymentCompletionDate { get; set; }

        [Required]
        public bool InShoppingCart { get; set; } = true;
    }
}
