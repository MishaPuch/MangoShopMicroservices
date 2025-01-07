using MangoShopGateWay.ModelDto;
using MangoShopGateWay.ModelDto.AggregationModel;
using MangoShopGateWay.ModelDto.Product;
using Newtonsoft.Json;
using Ocelot.Middleware;
using Ocelot.Multiplexer;

namespace MangoShopGateWay.Agregators
{
    public class ProductsWarehousesAggregator : IDefinedAggregator
    {
        public async Task<DownstreamResponse> Aggregate(List<HttpContext> responses)
        {
            var productDetailsResponse = await responses[0].Items.DownstreamResponse().Content.ReadAsStringAsync();
            var warehouseDetailsResponse = await responses[1].Items.DownstreamResponse().Content.ReadAsStringAsync();

            var productsDetails = JsonConvert.DeserializeObject<List<ProductApiResponse>>(productDetailsResponse);
            var warehousesDetails = JsonConvert.DeserializeObject<List<WarehouseApiResponse>>(warehouseDetailsResponse);

            var aggregatedList = warehousesDetails.Select(warehouse =>
            {
                var product = productsDetails.FirstOrDefault(p => p.Id == warehouse.ProductId);

                return new AggregatedWarehouseProduct
                {
                    Id = warehouse.Id,
                    ProductId = warehouse.ProductId,
                    GeneralProductName = warehouse.GeneralProductName,
                    ProductQuantity = warehouse.ProductQuantity,
                    Product = product
                };
            }).ToList();

            var json = JsonConvert.SerializeObject(aggregatedList);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            return new DownstreamResponse(content, System.Net.HttpStatusCode.OK, new List<KeyValuePair<string, IEnumerable<string>>>(), "application/json");
        }
    }
}
