using AutoMapper;
using MarketGraphQL.Abstraction;
using MarketGraphQL.Models;
using MarketGraphQL.Models.Dto;
using Microsoft.Extensions.Caching.Memory;

namespace MarketGraphQL.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly AppDbContext _contex;
        private IMapper _mapper;
        private IMemoryCache _cache;

        public CategoryService(AppDbContext contex, IMapper mapper, IMemoryCache cache)
        {
            _contex = contex;
            _mapper = mapper;
            _cache = cache;
        }

        public int AddCategory(CategoryDto categoryDto)
        {
            using (_contex)
            {
                var entity = _mapper.Map<Category>(categoryDto);
                _contex.Categories.Add(entity);
                _contex.SaveChanges();
                _cache.Remove("categoryes");
                return entity.Id;
            }
        }

        public IEnumerable<CategoryDto> GetCategories()
        {
            using (_contex)
            {
                if (_cache.TryGetValue("catogories", out List<CategoryDto> categories))
                {
                    return categories;
                }
                categories = _contex.Categories.Select(x => _mapper.Map<CategoryDto>(x)).ToList();
                _cache.Set("catogories", categories, TimeSpan.FromMinutes(30));
                return categories;
            }
        }
    }
}
