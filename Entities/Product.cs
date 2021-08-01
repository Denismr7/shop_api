using System;

namespace Shop.Entities
{
    public record Product
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public decimal Price { get; init; }
        public string Description { get; init; }
    }
}