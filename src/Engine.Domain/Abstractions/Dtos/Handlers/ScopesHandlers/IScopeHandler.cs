using Engine.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Engine.Domain.Abstractions.Dtos.Handlers.ScopesHandlers
{
    public interface IScopeHandler
    {
        public Task<Result> CreateScope(Scope scope);
        public Task<Scope> GetScopeById(int scopeId);
        public Task<List<Scope>> GetScopes();
        public Task<bool> UpdateScope(int scopeId, Scope scope);
        public Task<bool> DeleteScope(int scopeId);
    }
}
