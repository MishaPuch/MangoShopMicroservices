using MangoShopWorehouseService.Interface.RepositoryInterfaces;
using MangoShopWorehouseService.Interface.ServiceInterface;
using MangoShopWorehouseService.Model;
using Microsoft.CodeAnalysis;

namespace MangoShopWorehouseService.Service
{
    public class WorehouseService : IWorehouseService
    {
        private readonly IWorehouseRepository _worehouseRepository;
        public WorehouseService(IWorehouseRepository worehouseRepository)
        {
            _worehouseRepository = worehouseRepository;
        }

        public async Task<bool> ChangeProductQuantity(int productId, int quantity)
        {
            return await _worehouseRepository.ChangeProductQuantity(productId, quantity);
        }

        public async Task<bool> DeleteWorehouseById(int productId)
        {
            return await _worehouseRepository.DeleteWorehouseById(productId);
        }

        public async Task<List<Worehouse>> GetWorehouseByProductId(int productId)
        {
            return await _worehouseRepository.GetWorehouseByProductId(productId);
        }

        public async Task<Worehouse> GetWorehouseById(int id)
        {
            return await _worehouseRepository.GetWorehouseById(id);
        }

        public async Task<List<Worehouse>> GetWorehouses()
        {
            return await _worehouseRepository.GetWorehouses();
        }

        public async Task<List<Worehouse>> GetWorehousesByGeneralNameOfProduct(string generalName)
        {
            return await _worehouseRepository.GetWorehousesByGeneralNameOfProduct(generalName);
        }

        public async Task<bool> MakeOrder(int productId, int quantity)
        {
            return await _worehouseRepository.MakeOrder(productId, quantity);
        }

        public async Task<Worehouse> AddWorehouse(Worehouse worehouse)
        {
            return await _worehouseRepository.AddWorehouse(worehouse);
        }

        public async Task<bool> DeleteWorehouseByProductId(int productId)
        {
             return await _worehouseRepository.DeleteWorehouseByProductId(productId);
        }
    }
}