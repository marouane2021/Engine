using Engine.Domain.Abstractions.Dtos.Handlers.ScopesHandlers;
using Engine.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Domain.Handlers
{
    public class ScopeHandler : IScopeHandler
    {
        private readonly IScopeRepository _scopeRepository;
        public ScopeHandler(IScopeRepository scopeRepository)
        {
            _scopeRepository = scopeRepository ?? throw new ArgumentNullException(nameof(scopeRepository));
        }
        public async Task<Result> CreateScope(Scope scope)
        {
            var result = new Result();
            var errorList = new List<string>();
            var x = ValidateFields(scope, errorList);
            errorList.AddRange(x);

            if (errorList.Count != 0)
            {
                result.Errors = errorList;
                return result;
            }
            bool exist = await _scopeRepository.GetScopeByCode(scope.ScopeId);
            if (exist)
            {
                errorList.Add($"Scope Exist");
                result.Errors = errorList;
                return result;
            }
            result.ScopeId = await _scopeRepository.CreateScope(scope);
            return result;
        }

        private static List<string> ValidateFields(Scope scope, List<string> errorList)
        {
            if (scope == null)
            {
                errorList.Add($"Scope is null");

            }
            if (scope.ScopeId <= 0)
            {
                errorList.Add($"Scope Id not accepted, try again ");
            }
            return errorList;
        }

        public async Task<Scope> GetScopeById(int scopeId)
        {

            var scope = await _scopeRepository.GetScopeById(scopeId).ConfigureAwait(false);

            if (scope == null)
                return null;

            return scope;
        }

        public async Task<List<Scope>> GetScopes()
        {
            return await _scopeRepository.GetScopes();
        }

        public async Task<bool> UpdateScope(int scopeId, Scope scope)
        {
            if (scope == null)
            {
                return false;
            }

            return await _scopeRepository.UpdateScope(scopeId, scope);
        }

        public async  Task<bool> DeleteScope(int scopeId)
        {
            return await _scopeRepository.DeleteScope(scopeId);
        }

        
    }

 }


