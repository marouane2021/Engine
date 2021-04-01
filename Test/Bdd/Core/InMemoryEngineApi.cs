using Engine.Domain.Abstractions.Dtos.Handlers;
using Engine.Domain.Models;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Cds.Engine.Tests.Bdd.Core
{
    public class InMemoryEngineApi : IEngineRepository
    {
        public static Table Table { get; set; }

        public InMemoryEngineApi() { }
        public InMemoryEngineApi(Table table)
        {
            Table = table;
        }

        public Task<MyEngine> GetEngineById(int code)
        {
            if (Table.Rows.Count == 0)
                return Task.FromResult<MyEngine>(null);

            var engine = new MyEngine
            {
                Id = new ObjectId(Table.Rows[0][1]),
                Code = int.Parse(Table.Rows[0][2]),
                Name = Table.Rows[0][3]
            };

            return Task.FromResult(engine);
        }
        public Task<List<MyEngine>> GetEngines()
        {
            if (Table.Rows.Count == 0)
                return Task.FromResult<List<MyEngine>>(null);

            var tableRead = new List<MyEngine>();
            foreach (var item in Table.Rows)
            {
                tableRead.Add(new MyEngine
                {
                    Id = new ObjectId(item["Id"]),
                    Code = int.Parse(item["Code"]),
                    Name = item["Name"]


                });
            }
            return Task.FromResult(tableRead);
        }
        public Task<ObjectId> CreateEngine(MyEngine moteur)
        {
            throw new NotImplementedException();
        }

        public Task<bool> GetEngineByCode(int code)
        {
            throw new NotImplementedException();
        }
        public Task<bool> UpdateEngine(int code, MyEngine engine)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteEngine(int code)
        {
            throw new NotImplementedException();
        }


    }
}

        
