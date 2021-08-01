using Shop.Dtos;
using Shop.Entities;

namespace Shop
{
    public static class Extensions 
    {
        public static ProductDTO AsDto(this Product product)
        {
            return new() { Id = product.Id, Description = product.Description, Name = product.Name, Price = product.Price };
        }
    }
}