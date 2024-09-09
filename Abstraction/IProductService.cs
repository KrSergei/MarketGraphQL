using MarketGraphQL.Models.Dto;

namespace MarketGraphQL.Abstraction
{
    public interface IProductService
    {
        public IEnumerable<ProductDto> GetProducts();
        public int AddProduct(ProductDto productDto);     
    }
}
