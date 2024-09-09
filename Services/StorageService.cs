using AutoMapper;
using MarketGraphQL.Abstraction;
using MarketGraphQL.Models;
using MarketGraphQL.Models.Dto;
using Microsoft.Extensions.Caching.Memory;

namespace MarketGraphQL.Services
{
    public class StorageService : IStorageService
    {
        private readonly AppDbContext _contex;
        private IMapper _mapper;
        private IMemoryCache _cache;

        public StorageService(AppDbContext contex, IMapper mapper, IMemoryCache cache)
        {
            _contex = contex;
            _mapper = mapper;
            _cache = cache;
        }

        public int AddStorage(StorageDto storageDto)
        {
            using (_contex)
            {
                var entity = _mapper.Map<Storage>(storageDto);
                _contex.Storages.Add(entity);
                _contex.SaveChanges();
                _cache.Remove("storages");
                return entity.Id;
            }
        }

        public IEnumerable<StorageDto> GetStorages()
        {
            using (_contex)
            {
                if (_cache.TryGetValue("storages", out List<StorageDto> storages))
                {
                    return storages;
                }
                storages = _contex.Storages.Select(x => _mapper.Map<StorageDto>(x)).ToList();
                _cache.Set("storages", storages, TimeSpan.FromMinutes(30));
                return storages;
            }
        }
    }
}
