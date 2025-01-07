using MangoShopGateWay.ModelDto.Product;


namespace MangoShopGateWay.ModelDto.AggregationModel
{
    public class AggregatedBasketProduct : MangoShopGateWay.ModelDto.Basket.Basket
    {
        public ProductApiResponse Product { get; set; }
    }
}
