using MangoShopGateWay.ModelDto;
using MangoShopGateWay.ModelDto.Product;
using Newtonsoft.Json;
using Ocelot.Middleware;
using Ocelot.Multiplexer;

namespace MangoShopGateWay.Agregators
{
    public class ProductWarehouseAggregator : IDefinedAggregator
    {
        public async Task<DownstreamResponse> Aggregate(List<HttpContext> responses)
        {
            var productDetailsResponse = await responses[0].Items.DownstreamResponse().Content.ReadAsStringAsync();
            var warehouseDetailsResponse = await responses[1].Items.DownstreamResponse().Content.ReadAsStringAsync();

            var productDetails = JsonConvert.DeserializeObject<ProductApiResponse>(productDetailsResponse);
            var warehouseDetails = JsonConvert.DeserializeObject<WarehouseApiResponse>(warehouseDetailsResponse);

            var aggregatedResult = new
            {
                Product = productDetails,
                Warehouse = warehouseDetails
            };

            var json = JsonConvert.SerializeObject(aggregatedResult);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            return new DownstreamResponse(content, System.Net.HttpStatusCode.OK, new List<KeyValuePair<string, IEnumerable<string>>>(), "application/json");
        }
    }

}
