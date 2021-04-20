using PoznajRzeszow.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoznajRzeszow.Domain.Interfaces.Repositories
{
    public interface IVisitRepository
    {
        public Task CreateAsync(Visit place);
        public Task<Visit> GetAsync(Guid placeId, Guid userId);
        public Task UpdateAsync(Visit place);
    }
}
