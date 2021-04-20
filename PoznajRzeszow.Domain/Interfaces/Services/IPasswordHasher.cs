using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoznajRzeszow.Domain.Interfaces.Services
{
    public interface IPasswordHasher
    {
        string GenerateHash(string password, string salt);
        string GenerateSalt();
        bool Validate(string password, string salt, string hashedPassword);
    }
}
