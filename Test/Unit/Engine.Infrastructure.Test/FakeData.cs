using Engine.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Engine.Infrastructure.Test
{
    public static class FakeData
    {
        public static List<MyReadEngine> GetEngines()
        {
            return new List<MyReadEngine>()
            {
               new MyReadEngine()
               {
                    
                    Code = 1,
                    Id = 1,
                    IsEnable = true,
                    Name = "Beaute",
                    
               }
               ,
               new MyReadEngine()
               {
                   
                    Code = 2,
                    Id = 2,
                    IsEnable = true,
                   Name = "Billet",
                    
               }
            };
        }
    }
}
