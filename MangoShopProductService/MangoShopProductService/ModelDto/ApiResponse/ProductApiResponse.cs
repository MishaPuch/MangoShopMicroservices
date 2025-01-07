namespace MangoShopProductService.ModelDto.ApiResponse
{
    public class ProductApiResponse
    {
        public int Id { get; set; }
        public string GeneralProductName { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public CategoryApiResponse Category { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }
        public CurrencyApiResponse Currency { get; set; }
        public int Rating { get; set; }
    }
}
