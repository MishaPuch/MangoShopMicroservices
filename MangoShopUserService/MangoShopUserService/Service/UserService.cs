using MangoShopUserService.Model;
using Microsoft.EntityFrameworkCore;

namespace MangoShopUserService.Service
{
    public class UserService
    {
        private readonly AppDbContext _context;
        public UserService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _context.Users.Include(x => x.Permission).ToListAsync();
        }
        public async Task<User> GetUsersByIdAsync(int id)
        {
            return await _context.Users.Include(x => x.Permission).FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<User> GetLoginUser(string email, string password)
        {
            return await _context.Users.Include(x => x.Permission).FirstOrDefaultAsync(x => (x.Email == email) && (x.Password == password));
        }
        public async Task<bool> CreateUser(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> UpdateUser(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteUser(User user)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
