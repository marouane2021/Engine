using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace Engine.Domain.Models
{
    public class Result
    {
        public ObjectId Id { get; set; }
        public IList<string> Errors { get; set; }
    }
}
