using System.Collections.Generic;

namespace Engine.Domain.Models
{
    public class InputField
    {
        public int InputId { get; set; } // input id
        public bool IsEnable { get; set; } // the input is enable or not
        public bool IsMandatory { get; set; } // if the input is required
        public string Label { get; set; } // label of the input
        public int Order { get; set; } // the order
        public string Type { get; set; } // type of the input
        public IList<Parameter> Parameters { get; set; } // list of the parameters
    }
}
