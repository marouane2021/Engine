﻿namespace Engine.Domain.Models
{
    public class Scope
    {
        public int ScopeId { get; set; }
        public int Order { get; set; }
        public string Name { get; set; }
        public bool IsEnable { get; set; }
    }
}