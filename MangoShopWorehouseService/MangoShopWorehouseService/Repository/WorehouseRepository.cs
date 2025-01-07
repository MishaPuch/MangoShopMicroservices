using MangoShopWorehouseService.Interface.RepositoryInterfaces;
using MangoShopWorehouseService.Model;
using Microsoft.EntityFrameworkCore;
using NuGet.Packaging.Signing;

namespace MangoShopWorehouseService.Repository
{
    public class WorehouseRepository : IWorehouseRepository
    {
        private readonly AppDbContext _appDbContext;
        public WorehouseRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Worehouse> AddWorehouse(Worehouse worehouse)
        {
            if(worehouse == null) throw new ArgumentNullException(nameof(worehouse));
            await _appDbContext.Worehouses.AddAsync(worehouse);
            await _appDbContext.SaveChangesAsync();
            return worehouse;
        }

        public async Task<bool> ChangeProductQuantity(int Id, int quantity)
        {
            if (quantity < 0)
            {
                return false;
            }
            var worehouse = await GetWorehouseById(Id);
            if (worehouse != null)
            {
                worehouse.ProductQuantity = quantity;
                _appDbContext.Update(worehouse);
                await _appDbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteWorehouseById(int Id)
        {
            var worehouse = await GetWorehouseById(Id);
            if (worehouse != null)
            {
                _appDbContext.Worehouses.Remove(worehouse);
                await _appDbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteWorehouseByProductId(int productId)
        {
            var worehouse = await GetWorehouseByProductId(productId);
            if (worehouse != null)
            {
                _appDbContext.Worehouses.RemoveRange(worehouse);
                await _appDbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<Worehouse> GetWorehouseById(int id)
        {
            return await _appDbContext.Worehouses.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Worehouse>> GetWorehouseByProductId(int productId)
        {
            return await _appDbContext.Worehouses.Where(x => x.ProductId == productId).ToListAsync();
        }

        public async Task<List<Worehouse>> GetWorehouses()
        {
            return await _appDbContext.Worehouses.ToListAsync();
        }   

        public async Task<List<Worehouse>> GetWorehousesByGeneralNameOfProduct(string generalName)
        {
            return await _appDbContext.Worehouses.Where(x => x.GeneralProductName == generalName).ToListAsync();
        }

        public async Task<bool> MakeOrder(int productId, int quantity)
        {
            var worehouse = await GetWorehouseById(productId);
            if(worehouse.ProductQuantity - quantity > 0)
            {
                await ChangeProductQuantity(productId, worehouse.ProductQuantity - quantity);
                return true;
            }
            return false; 

        }
    }
}
