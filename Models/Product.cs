namespace MarketGraphQL.Models
{
    public class Product 
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string Description { get; set; } = null!;
        public int Price { get; set; }
        public int Category_Id { get; set; }
        public virtual Category Category { get; set; } = null!;
        public virtual List<Storage> Storages { get; set; } = null!;
    }
}