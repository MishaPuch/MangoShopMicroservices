using MangoShopGateWay.ModelDto.Product;

namespace MangoShopGateWay.ModelDto.AggregationModel
{
    public class AggregatedWarehouseProduct : WarehouseApiResponse
    {
        public ProductApiResponse Product { get; set; }
    }
}
