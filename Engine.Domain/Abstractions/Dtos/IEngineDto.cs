using System;
using System.Collections.Generic;
using System.Text;

namespace Engine.Domain.Abstractions.Dtos
{
   public  interface IEngineDto
    {
       string name { get; set; }

        /// <summary>
        /// Gets or sets the scope identifier.
        /// </summary>
        /// <value>
        /// The scope identifier.
        /// </value>
        int code { get; set; }

        /// <summary>
        /// Gets or sets the scope identifier.
        /// </summary>
        /// <value>
        /// The scope identifier.
        /// </value>
        /// 
        bool isEnable { get; set; }

        /// <summary>
        /// Gets or sets the scope identifier.
        /// </summary>
        /// <value>
        /// The scope identifier.
        /// </value>
        /// 
         string searchText { get; set; }
        /// <summary>
        /// Gets the list of all Employees.
        /// </summary>
        /// <returns>The list of Employees.</returns>
        // GET: api/Input
       IScopesDto Scopes { get; set; }
        IInputDto Input { get; set; }

        ILogoDto Logo { get; set; }
        IBackgroundDto Background { get; set; }
      IMarketingDto MarketingText { get; set; }
    }
}
