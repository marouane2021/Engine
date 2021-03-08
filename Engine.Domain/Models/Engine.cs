using Engine.Domain.Abstractions.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using MongoDB.Bson.Serialization.Attributes;

namespace Engine.Domain.Models
{ /// <summary>
  /// 
  /// </summary>
    public class Engine

    {
        public IInputDto inputFields;

        [BsonId]
        public int Id { get; set; }


        /// <summary>
        /// Gets or sets the scope identifier.
        /// </summary>
        /// <value>
        /// The scope identifier.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the scope identifier.
        /// </summary>
        /// <value>
        /// The scope identifier.
        /// </value>
        public int code { get; set; }

        /// <summary>
        /// Gets or sets the scope identifier.
        /// </summary>
        /// <value>
        /// The scope identifier.
        /// </value>
        /// 
        public bool isEnable { get; set; }

        /// <summary>
        /// Gets or sets the scope identifier.
        /// </summary>
        /// <value>
        /// The scope identifier.
        /// </value>
        /// 
        public string searchText { get; set; }
        /// <summary>
        /// Gets the list of all Employees.
        /// </summary>
        /// <returns>The list of Employees.</returns>
        // GET: api/Input
        public List<Scopes> Scopes { get; set; }
        public List<Input> InputFields { get; set; }

        public List<Logo> logo { get; set; }
        public List<Background> backgroundImages { get; set; }
        public List<Marketing> marketingText { get; set; }
       
        public static Engine Create()
        {
            return new Engine();
        }

        public Engine WithCode(int scopeId)
        {
            code = scopeId;
            return this;
        }



        public Engine FromUpdatedEnginesDto(IEngineDto updatedEngine)
        {
            if (updatedEngine != null)
            {
                return this;
            } 
                                
                    return null;
        }

    }
    }

