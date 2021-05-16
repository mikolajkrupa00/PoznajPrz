using PoznajRzeszow.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoznajRzeszow.Domain.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetAsync(Guid userId);
        Task<User> GetAsync(string username);
        Task<User> GetByEmailAsync(string email);
        Task CreateAsync(User user);
        Task UpdateAsync(User user);
    }
}
