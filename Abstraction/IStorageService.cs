using MarketGraphQL.Models.Dto;

namespace MarketGraphQL.Abstraction
{
    public interface IStorageService
    {
        public IEnumerable<StorageDto> GetStorages();
        public int AddStorage(StorageDto storageDto);
    }
}
