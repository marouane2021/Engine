using Engine.Domain.Abstractions.Dtos.Handlers.ScopesHandlers;
using Engine.Domain.Models;
using EngineApi.Api.Bootstrap;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EngineApi.Api.Controllers.Scopes
{
    [Produces("application/json")]
    [ApiController]
    [Route("Scope")]
    public class ScopesController : ControllerBase
    {
        private readonly IScopeHandler _handlerScope;
        // private readonly ILogger<EnginesController> _logger;
        private readonly MetricReporter _metrics;
      

        /// <summary>
        /// Initializes a new instance of the <see cref="ScopesController"/> class.
        /// </summary>
        /// <param name="handlerScope">The handler engine.</param>
        public ScopesController(IScopeHandler handlerScope)
        {
            _handlerScope = handlerScope ?? throw new ArgumentNullException(nameof(handlerScope));
            
        }

        /// <summary>
        /// Creates the engine asynchronous.
        /// </summary>
        /// <param name="scope">The engine.</param>
        /// <returns></returns>
        [HttpPost("CreateScope")]
        [SwaggerResponse(StatusCodes.Status201Created, description: "WELL DONE")]
        [SwaggerResponse(StatusCodes.Status405MethodNotAllowed, description: "WELL DONE")]
  
        public async Task<IActionResult> CreateScopeAsync([FromBody] Scope scope)
        {
            try
            {
                var res = await _handlerScope.CreateScope(scope);
                if (res.Errors != null && res.Errors.Count != 0)
                    return StatusCode(StatusCodes.Status405MethodNotAllowed, res.Errors);
                return StatusCode(StatusCodes.Status201Created, res.ScopeId);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        [HttpGet("GetScopeById/{scopeId}")]
        [SwaggerResponse(StatusCodes.Status200OK, description: "WELL DONE")]
        [SwaggerResponse(StatusCodes.Status404NotFound, description: "Aucune donnée")]
        public async Task<ActionResult> GetScopeById([FromRoute] int scopeId)
        {
            var result = await _handlerScope.GetScopeById(scopeId);

            if (result == null)
            {
                return NotFound($"No Scope found with this Id : {scopeId}");
            }

            return Ok(result);
        }

        [HttpGet("GetAll/Scopes")]
        [SwaggerResponse(StatusCodes.Status200OK, description: "toto")]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetScopes()
        {
            var result = await _handlerScope.GetScopes();

            if (result == null || !result.Any())
            {
                return NotFound();
            }

            return Ok(result);

        }
        [HttpPut("UpdateScope/{scopeId}")]
        [SwaggerResponse(StatusCodes.Status200OK, description: "WELL DONE")]
        [SwaggerResponse(StatusCodes.Status404NotFound, description: "Aucune donnée")]
        public async Task<IActionResult> UpdateScopeAsync([FromRoute] int scopeId, [FromBody] Scope scope)
        {
            var result = await _handlerScope.UpdateScope(scopeId, scope);

            if (!result)
            {
                return NotFound($"No Scope found with this Id : {scopeId}");
            }

            return Ok($"Scope Updated");
        }
        [HttpDelete("DeleteScope/{scopeId}")]
        [SwaggerResponse(StatusCodes.Status200OK, description: "WELL DONE")]
        [SwaggerResponse(StatusCodes.Status404NotFound, description: "Aucune donnée")]
        public async Task<IActionResult> DeleteScopeAsync([FromRoute] int scopeId)
        {
            var result = await _handlerScope.DeleteScope(scopeId);

            if (!result)
            {
                return NotFound($"No Scope found with this Id : {scopeId}");
            }

            return Ok($"Scope Deleted");
        }






    }

}
