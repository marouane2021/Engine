using Engine.Domain.Abstractions.Dtos.Handlers.Groupes_Handlers;
using Engine.Domain.Models;
using EngineApi.Api.Bootstrap;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EngineApi.Api.Controllers.Groupes
{
    [Produces("application/json")]
    [ApiController]
    [Route("Groupe")]
    public class GroupeController : ControllerBase
    {
        private readonly IGroupeHandler _handlerGroupe;
        // private readonly ILogger<EnginesController> _logger;
        private readonly MetricReporter _metrics;


        /// <summary>
        /// Initializes a new instance of the <see cref="GroupesController"/> class.
        /// </summary>
        /// <param name="handlerGroupe">The handler engine.</param>
        public GroupeController(IGroupeHandler handlerGroupe)
        {
            _handlerGroupe = handlerGroupe ?? throw new ArgumentNullException(nameof(handlerGroupe));

        }

        /// <summary>
        /// Creates the engine asynchronous.
        /// </summary>
        /// <param name="scope">The engine.</param>
        /// <returns></returns>
        [HttpPost("CreateGroupes")]
        [SwaggerResponse(StatusCodes.Status201Created, description: "WELL DONE")]
        [SwaggerResponse(StatusCodes.Status405MethodNotAllowed, description: "WELL DONE")]

        public async Task<IActionResult> CreateGroupeAsync([FromBody] Groupe groupe)
        {
            try
            {
                var res = await _handlerGroupe.CreateGroupe(groupe);
                if (res.Errors != null && res.Errors.Count != 0)
                    return StatusCode(StatusCodes.Status405MethodNotAllowed, res.Errors);
                return StatusCode(StatusCodes.Status201Created, res.GroupId);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        [HttpGet("GetGroupeById/{groupeId}")]
        [SwaggerResponse(StatusCodes.Status200OK, description: "WELL DONE")]
        [SwaggerResponse(StatusCodes.Status404NotFound, description: "Aucune donnée")]
        public async Task<ActionResult> GetGroupeById([FromRoute] int groupeId)
        {
            var result = await _handlerGroupe.GetGroupeById(groupeId);

            if (result == null)
            {
                return NotFound($"No Groupe found with this Id : {groupeId}");
            }

            return Ok(result);
        }

        [HttpGet("GetAll/Groupes")]
        [SwaggerResponse(StatusCodes.Status200OK, description: "toto")]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetGroupes()
        {
            var result = await _handlerGroupe.GetGroupes();

            if (result == null || !result.Any())
            {
                return NotFound();
            }

            return Ok(result);

        }
        [HttpPut("UpdateGroupe/{groupeId}")]
        [SwaggerResponse(StatusCodes.Status200OK, description: "WELL DONE")]
        [SwaggerResponse(StatusCodes.Status404NotFound, description: "Aucune donnée")]
        public async Task<IActionResult> UpdateGroupeAsync([FromRoute] int groupeId, [FromBody] Groupe groupe)
        {
            var result = await _handlerGroupe.UpdateGroupe(groupeId, groupe);

            if (!result)
            {
                return NotFound($"No Groupe found with this Id : {groupeId}");
            }

            return Ok($"Groupe Updated");
        }
        [HttpDelete("DeleteGroupe/{groupeId}")]
        [SwaggerResponse(StatusCodes.Status200OK, description: "WELL DONE")]
        [SwaggerResponse(StatusCodes.Status404NotFound, description: "Aucune donnée")]
        public async Task<IActionResult> DeleteGroupeAsync([FromRoute] int groupeId)
        {
            var result = await _handlerGroupe.DeleteGroupe(groupeId);

            if (!result)
            {
                return NotFound($"No Groupe found with this Id : {groupeId}");
            }

            return Ok($"Groupe Deleted");
        }





    }
}
