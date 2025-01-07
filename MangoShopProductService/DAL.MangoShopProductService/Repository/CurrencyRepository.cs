using DAL.MangoShopProductService.Model;
using Microsoft.EntityFrameworkCore;

namespace DAL.MangoShopProductService.Repository
{
    public class CurrencyRepository
    {
        private readonly AppDbContext _context;

        public CurrencyRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Currency>> GetAllCurrenciesAsync()
        {
            return await _context.Currencies.ToListAsync();
        }

        public async Task<Currency?> GetCurrencyByIdAsync(int id)
        {
            return await _context.Currencies.FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
