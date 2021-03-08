using System;
using System.Collections.Generic;
using System.Text;

namespace Engine.Domain.Models
{
    public class Input
    { 

            /// <summary>
            /// Gets or sets the scope identifier.
            /// </summary>
            /// <value>
            /// The scope identifier.
            /// </value>
            
        public int id { get; set; }

        /// <summary>
        /// Gets or sets the scope identifier.
        /// </summary>
        /// <value>
        /// The scope identifier.
        /// </value>
        public string type { get; set; }
        /// <summary>
        /// Gets or sets the scope identifier.
        /// </summary>
        /// <value>
        /// The scope identifier.
        /// </value>
        public string label { get; set; }
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
        public bool isMandatory { get; set; }
        public List<Parameters> Parameters { get; set; }
    }
}

