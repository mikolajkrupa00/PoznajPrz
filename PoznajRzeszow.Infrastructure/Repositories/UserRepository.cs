using Microsoft.EntityFrameworkCore;
using PoznajRzeszow.Domain.Interfaces.Repositories;
using PoznajRzeszow.Domain.Models;
using PoznajRzeszow.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoznajRzeszow.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly PoznajRzeszowContext _context;

        public UserRepository(PoznajRzeszowContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(User user)
        {
            await _context.Users.AddAsync(DbUser.Create(user));
            await _context.SaveChangesAsync();
        }

        public async Task<User> GetAsync(string username)
            => await (from u in _context.Users
                      where u.Username == username
                      select new User(u.UserId, u.Email, u.Username, u.Password, u.Salt, u.Role))
            .FirstOrDefaultAsync();

        public async Task<User> GetAsync(Guid userId)
            => await (from u in _context.Users
                          where u.UserId == userId
                          select new User(u.UserId, u.Email, u.Username, u.Password, u.Salt, u.Role)).FirstAsync();

        public async Task UpdateAsync(User user)
        {
            var _user = await (from u in _context.Users
                               where u.UserId == user.UserId
                               select u).FirstAsync();
            _user.Email = user.Email;
            _user.Password = user.Password;
            _user.Role = user.Role;
            _user.Username = user.Username;
            await _context.SaveChangesAsync();
        }
    }
}
