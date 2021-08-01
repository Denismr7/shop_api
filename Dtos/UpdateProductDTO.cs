using System.ComponentModel.DataAnnotations;

namespace Shop.Dtos
{
    public record UpdateProductDTO
    {
        [Required]
        public string Name { get; init; }
        [Required]
        [Range(1, 10000)]
        public decimal Price { get; init; }
        [Required]
        public string Description { get; init; }
    }
}