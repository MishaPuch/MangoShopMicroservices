namespace DAL.MangoShopProductService.Model
{
    public class Product
    {
        public int Id { get; set; }
        public string GeneralProductName { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }
        public int CurrencyId { get; set; }
        public Currency Currency { get; set; }
        public int Rating { get; set; }
    }
}
