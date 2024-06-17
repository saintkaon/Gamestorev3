using Gamestore.Models;
using Gamestorev3.Server.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Gamestorev3.Server.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly StoreDbContext _context;

        public UserRepository(StoreDbContext context)
        {
            _context = context;
        }

        public async Task<Users> GetUserbyEmailAsync(string email)
        {
            return await _context.Users.SingleOrDefaultAsync(x=>x.EmailAddress == email);
        }

        public async Task<Users> GetUserbyIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public Task<IEnumerable<Users>> GetUsers()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Users>> GetUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }


        public void Update(Users user)
        {
            _context.Users.Entry(user).State = EntityState.Modified;
        }

        public void update(Users user)
        {
            throw new NotImplementedException();
        }
    }
}
