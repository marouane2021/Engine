using Cds.SearchEngineEditor.Domain.EngineAggregate.Dto;
using Cds.SearchEngineEditor.Domain.ScopeAggregate.Abstractions;
using Cds.SearchEngineEditor.Domain.ScopeAggregate.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cds.SearchEngineEditor.Tests.Bdd.InMemoryRepository
{
    /// <summary>
    /// InMemory ScopeRead Repository
    /// </summary>
    /// <seealso cref="Cds.SearchEngineEditor.Domain.ScopeAggregate.Abstractions.IScopeReadRepository" />
    public class InMemoryScopeReadRepository : IScopeReadRepository
    {
        /// <summary>
        /// Get enginesId with his engines scopes.
        /// </summary>
        /// <param name="listEngineId"></param>
        /// <returns>
        /// Dictionnary of enginesId with his engines scopes.
        /// </returns>
        public async Task<Dictionary<int, List<EngineScopeDto>>> GetScopesAsync(IEnumerable<int> listEngineId)
        {
            return await Task.FromResult(GetScopesForEngineId()).ConfigureAwait(false);
        }

        /// <summary>
        /// Get All scope
        /// </summary>
        /// <returns>
        /// List PartialScope
        /// </returns>
        public async Task<List<ScopeDto>> GetScopeAsync()
        {
            return await Task.FromResult(new List<ScopeDto> { GetScopeDto(1), GetScopeDto(2) }).ConfigureAwait(false);
        }

        /// <summary>
        /// Get scope by scopeID.
        /// </summary>
        /// <param name="scopeId"></param>
        /// <returns>
        /// ScopeDto
        /// </returns>
        public async Task<ScopeDto> GetScopeByIdAsync(int scopeId)
        {
            if (scopeId == 1)
            {
                return await Task.FromResult(GetScopeDto(1)).ConfigureAwait(false);
            }
            return await Task.FromResult<ScopeDto>(null).ConfigureAwait(false);
        }

        /// <summary>
        /// Get ScopeParameter by scopeID.
        /// </summary>
        /// <param name="scopeId"></param>
        /// <returns>
        /// List ScopeParameter
        /// </returns>
        public async Task<List<ScopeParameterDto>> GetScopeParametersAsync(int scopeId)
        {
            return await Task.FromResult(GetScopeParameters()).ConfigureAwait(false);
        }

        /// <summary>
        /// Get Scopes by enginID.
        /// </summary>
        /// <param name="engineId"></param>
        /// <returns>
        /// List EngineScopeDto
        /// </returns>
        public async Task<List<EngineScopeDto>> GetScopesByEngineIdAsync(int engineId)
        {
            if (engineId == 1)
            {
                return await Task.FromResult(GetEnginesWithScopes()).ConfigureAwait(false);
            }
            return await Task.FromResult(new List<EngineScopeDto>()).ConfigureAwait(false);
        }

        #region Private Methods

        /// <summary>
        /// Gets the scope parameters.
        /// </summary>
        /// <returns></returns>
        private List<ScopeParameterDto> GetScopeParameters()
        {
            return new List<ScopeParameterDto>
            {
                new ScopeParameterDto
                {
                     ScopeParameterID = 1,
                     Key = "param1",
                     ScopeParameterTypeID = 2
                },
                new ScopeParameterDto
                {
                     ScopeParameterID = 2,
                     Key = "param2",
                     ScopeParameterTypeID = 2
                }
            };
        }

        /// <summary>
        /// Gets the scope dto.
        /// </summary>
        /// <param name="scopeId">The scope identifier.</param>
        /// <returns></returns>
        private ScopeDto GetScopeDto(int scopeId)
        {
            return new ScopeDto
            {
                ScopeName = "scope de test",
                Urltemplate = "https://www.index.com/index.php?{test=1}&{test2=0}",
                ScopeID = scopeId,
                CreationDateOffset = DateTimeOffset.Parse("2020-05-28T00:00:00.0000000+02:00"),
            };
        }

        /// <summary>
        /// Gets the scopes for engine identifier.
        /// </summary>
        /// <returns></returns>
        private Dictionary<int, List<EngineScopeDto>> GetScopesForEngineId()
        {
            return new Dictionary<int, List<EngineScopeDto>>
            {
                { 1, new List<EngineScopeDto>{GetEnginesWithScopes().First() } },
                { 2, new List<EngineScopeDto>{GetEnginesWithScopes().Last() } }
            };
        }

        /// <summary>
        /// Gets the engines with scopes.
        /// </summary>
        /// <returns></returns>
        private List<EngineScopeDto> GetEnginesWithScopes()
        {
            return new List<EngineScopeDto>
            {
                new EngineScopeDto
                {
                    ScopeID = 1,
                    ScopeName = "scope de test1",
                    IsEngineScopeEnabled = true,
                    Label = "evol",
                    Order = 1,
                    IsEnable = true,
                    CreationDateOffset = DateTimeOffset.Parse("2020-06-05T10:39:21.201Z"),
                    UpdateDateOffset = DateTimeOffset.Parse("2020-06-05T10:39:21.201Z")
                },
                new EngineScopeDto
                {
                    ScopeID = 2,
                    IsEngineScopeEnabled = true,
                    ScopeName = "scope de test2",
                    Order = 2,
                    IsEnable = true,
                    Label = "EVOL",
                    CreationDateOffset = DateTimeOffset.Parse("2020-06-05T10:39:21.201Z"),
                    UpdateDateOffset = DateTimeOffset.Parse("2020-06-05T10:39:21.201Z")
                }
            };
        }

        #endregion
    }
}
