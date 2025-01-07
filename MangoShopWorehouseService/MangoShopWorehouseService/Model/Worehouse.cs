using Microsoft.AspNetCore.OpenApi;
using Microsoft.AspNetCore.Http.HttpResults;
namespace MangoShopWorehouseService.Model
{
    public class Worehouse
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string GeneralProductName { get; set; }
        public int ProductQuantity { get; set; }
    }

}
