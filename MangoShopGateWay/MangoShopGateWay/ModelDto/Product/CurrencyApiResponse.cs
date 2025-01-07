namespace MangoShopGateWay.ModelDto.Product
{
    public class CurrencyApiResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
        public decimal CoefficentForCurrency { get; set; } = 1;
    }
}
