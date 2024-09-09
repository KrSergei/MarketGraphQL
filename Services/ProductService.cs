using AutoMapper;
using MarketGraphQL.Abstraction;
using MarketGraphQL.Models;
using MarketGraphQL.Models.Dto;
using Microsoft.Extensions.Caching.Memory;

namespace MarketGraphQL.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _contex;
        private IMapper _mapper;
        private IMemoryCache _cache;

        public ProductService(AppDbContext contex, IMapper mapper, IMemoryCache cache)
        {
            _contex = contex;
            _mapper = mapper;
            _cache = cache;
        }

        public int AddProduct(ProductDto productDto)
        {
            using (_contex)
            {
               var entity = _mapper.Map<Product>(productDto);
                _contex.Products.Add(entity);
                _contex.SaveChanges();
                _cache.Remove("products");
                return entity.Id;
            }
        }

        public IEnumerable<ProductDto> GetProducts()
        {
            using (_contex)
            {   
                if(_cache.TryGetValue("products", out List<ProductDto> products))
                {
                    return products;
                }
                products = _contex.Products.Select(x => _mapper.Map<ProductDto>(x)).ToList();
                _cache.Set("products", products, TimeSpan.FromMinutes(30));
                return products;
            }
        }
    }
}
