using PoznajRzeszow.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoznajRzeszow.Domain.Interfaces.Services
{
    public interface IJwtGenerator
    {
        string Generate(Guid userId, Roles role);
    }
}
