using MangoShopGateWay.ModelDto;
using MangoShopGateWay.ModelDto.AggregationModel;
using MangoShopGateWay.ModelDto.Basket;
using MangoShopGateWay.ModelDto.Product;
using Newtonsoft.Json;
using Ocelot.Middleware;
using Ocelot.Multiplexer;

namespace MangoShopGateWay.Agregators
{
    public class ProductBasketAggregator : IDefinedAggregator
    {
        public async Task<DownstreamResponse> Aggregate(List<HttpContext> responses)
        {
            var productDetailsResponse = await responses[0].Items.DownstreamResponse().Content.ReadAsStringAsync();
            var basketDetailsResponse = await responses[1].Items.DownstreamResponse().Content.ReadAsStringAsync();

            var productsDetails = JsonConvert.DeserializeObject<List<ProductApiResponse>>(productDetailsResponse);
            var basketDetails = JsonConvert.DeserializeObject<List<Basket>>(basketDetailsResponse);

            var aggregatedList = basketDetails.Select(basket =>
            {
                var product = productsDetails.FirstOrDefault(p => p.Id == basket.ProductId);

                return new AggregatedBasketProduct
                {
                    Id = basket.Id,
                    ProductId = basket.ProductId,
                    ProductQuantity = basket.ProductQuantity,
                    Product = product,
                    UserId = basket.UserId,
                };
            }).ToList();

            var json = JsonConvert.SerializeObject(aggregatedList);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            return new DownstreamResponse(content, System.Net.HttpStatusCode.OK, new List<KeyValuePair<string, IEnumerable<string>>>(), "application/json");
        }
    }

}
