using MangoShopWorehouseService.Model;

namespace MangoShopWorehouseService.Interface.ServiceInterface
{
    public interface IWorehouseService
    {
        public Task<List<Worehouse>> GetWorehouses();
        public Task<List<Worehouse>> GetWorehouseByProductId(int productId);
        public Task<List<Worehouse>> GetWorehousesByGeneralNameOfProduct(string generalName);
        public Task<Worehouse> GetWorehouseById(int id);
        public Task<bool> MakeOrder(int productId, int quantity);
        public Task<Worehouse> AddWorehouse(Worehouse worehouse);
        public Task<bool> ChangeProductQuantity(int productId, int quantity);
        public Task<bool> DeleteWorehouseByProductId(int productId);
        public Task<bool> DeleteWorehouseById(int productId);
    }
}
