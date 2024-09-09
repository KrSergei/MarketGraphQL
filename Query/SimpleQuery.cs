using MarketGraphQL.Abstraction;
using MarketGraphQL.Models.Dto;

namespace MarketGraphQL.Query
{
    public class SimpleQuery
    {
        public IEnumerable<ProductDto> GetProducts([Service] IProductService productService) => productService.GetProducts();
        public IEnumerable<StorageDto> GetStorages([Service] IStorageService storageService) => storageService.GetStorages();
        public IEnumerable<CategoryDto> GetCategories([Service] ICategoryService categoryService) => categoryService.GetCategories();
    }
}
