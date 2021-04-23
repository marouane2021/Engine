using Engine.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Domain.Abstractions.Dtos.Handlers.ScopesHandlers
{
    public interface IScopeRepository
    {
        Task<int> CreateScope(Scope scope);
        Task<bool> GetScopeByCode(int scopeId);
        Task<Scope> GetScopeById(int scopeId);
        Task<List<Scope>> GetScopes();
        Task<bool> UpdateScope(int scopeId, Scope scope);
        Task<bool> DeleteScope(int scopeId);

    }
}
