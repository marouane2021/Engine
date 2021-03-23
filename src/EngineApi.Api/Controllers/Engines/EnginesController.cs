﻿using Engine.Domain.Abstractions.Dtos.Handlers;
using Engine.Domain.Handlers;
using EngineApi.Api.Bootstrap;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace EngineApi.Api.Controllers.Engines
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Produces("application/json")]
    [ApiController]
    [Route("Moteur")]
    public class EnginesController : ControllerBase
    {
        private readonly IEngineHandler _handlerEngine;
       // private readonly ILogger<EnginesController> _logger;
        private readonly MetricReporter _metrics;

        /// <summary>
        /// Initializes a new instance of the <see cref="EnginesController"/> class.
        /// </summary>
        /// <param name="handlerEngine">The handler engine.</param>
        public EnginesController(IEngineHandler handlerEngine, MetricReporter metrics)
        {
            _handlerEngine = handlerEngine ?? throw new ArgumentNullException(nameof(handlerEngine));
            _metrics = metrics;
        }

        /// <summary>
        /// Creates the engine asynchronous.
        /// </summary>
        /// <param name="engine">The engine.</param>
        /// <returns></returns>
        [HttpPost("CreateEngine")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> CreateEngineAsync([FromBody] Engine.Domain.Models.Engine engine)
        {
            try
            {
                var res = await _handlerEngine.CreateEngine(engine);
               
                
                    if (res.Errors != null && res.Errors.Count != 0)
                        return StatusCode(StatusCodes.Status404NotFound, res.Errors);
                   
                
                return StatusCode(StatusCodes.Status201Created, res.Id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        [HttpGet("GetEngineByCode/{code}")]
        [SwaggerResponse(StatusCodes.Status200OK, description: "WELL DONE")]
        [SwaggerResponse(StatusCodes.Status404NotFound, description: "Aucune donnée")]
        public async Task<IActionResult> GetEngineById([FromRoute] int code)
        {
            var result = await _handlerEngine.GetEngineById(code);

            if (result == null)
            {
                return NotFound($"No engine found with this code : {code}");
            }

            return Ok(result);
        }

        [HttpGet("GetAll/Engines")]
        [SwaggerResponse(StatusCodes.Status200OK, description: "toto")]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetEngines()
        {
            var result = await _handlerEngine.GetEngines();

            if (result == null || !result.Any())
            {
                return NotFound();
            }

            _metrics.RegisterRequest();

            //return Content(JsonConvert.SerializeObject(result, Formatting.Indented, new JsonSerializerSettings {​​​​​ContractResolver = new CamelCasePropertyNamesContractResolver() }​​​​​), "application/json");
            return Content(Newtonsoft.Json.JsonConvert.SerializeObject(result, Formatting.Indented, new JsonSerializerSettings()), "application/json");
        }


    }

}
