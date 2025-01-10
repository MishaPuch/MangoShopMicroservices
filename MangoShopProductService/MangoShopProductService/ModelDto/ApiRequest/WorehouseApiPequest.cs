namespace MangoShopProductService.ModelDto.ApiRequest
{
    public class WorehouseApiRequest
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string GeneralProductName { get; set; }
        public int ProductQuantity { get; set; }
    }
}
