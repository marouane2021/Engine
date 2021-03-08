using System;
using System.Collections.Generic;
using System.Text;

namespace Engine.Domain.Abstractions.Dtos
{
    public interface IMarketingDto
    {
        string text { get; set; }
        /// <summary>
        /// Gets or sets the scope identifier.
        /// </summary>
        /// <value>
        /// The scope identifier.
        /// </value>
        /// 
        bool isEnable { get; set; }
    }
}
