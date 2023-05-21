using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BooksStore.Models;
using BooksStore.Repository;

namespace BooksStore.Repository
{
    public class AuthenticateLogin : ILogin
    {
        private readonly LoginDbContext _context;

        public AuthenticateLogin(LoginDbContext context)
        {
            _context = context;
        }
        public async Task<UserLogin> AuthenticateUser(string username, string passcode)
        {
            var succeeded = await _context.UserLogin.FirstOrDefaultAsync(authUser => authUser.UserName == username && authUser.passcode == passcode);
            return succeeded;
        }

        public async Task<IEnumerable<UserLogin>> getuser()
        {
            return await _context.UserLogin.ToListAsync();
        }
    }
}