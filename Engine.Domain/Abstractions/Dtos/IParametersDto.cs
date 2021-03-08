using System;
using System.Collections.Generic;
using System.Text;

namespace Engine.Domain.Abstractions.Dtos
{
    public interface IParametersDto
    {
        int scopeParameterId { get; set; }

        /// <summary>
        /// Gets or sets the scope identifier.
        /// </summary>
        /// <value>
        /// The scope identifier.
        /// </value>
        /// 
        int externalCodeId { get; set; }

        /// <summary>
        /// Gets or sets the scope identifier.
        /// </summary>
        /// <value>
        /// The scope identifier.
        /// </value>
        /// 
        int order { get; set; }
        /// <summary>
        /// Gets or sets the scope identifier.
        /// </summary>
        /// <value>
        /// The scope identifier.
        /// </value>
        /// 
        string label { get; set; }
    }
}
