using MarketGraphQL.Models.Dto;

namespace MarketGraphQL.Abstraction
{
    public interface ICategoryService
    {
        public IEnumerable<CategoryDto> GetCategories();
        public int AddCategory(CategoryDto categoryDto);
    }
}
