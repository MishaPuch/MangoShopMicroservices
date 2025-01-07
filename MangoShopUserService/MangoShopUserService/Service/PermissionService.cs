using MangoShopUserService.Model;
using Microsoft.EntityFrameworkCore;

namespace MangoShopUserService.Service
{
    public class PermissionService
    {
        private readonly AppDbContext _context;
        public PermissionService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Permission>> GetAllPermissionsAsync()
        {
            return await _context.Permissions.ToListAsync();
        }
        public async Task<Permission> GetPermissionByIdAsync(int id)
        {
            return await _context.Permissions.FindAsync(id);
        }
    }
}
