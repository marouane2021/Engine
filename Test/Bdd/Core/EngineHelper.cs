using Engine.Domain.Models;
using MongoDB.Bson;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Cds.Engine.Tests.Bdd.Core
{
    public class EngineHelper
    {
        //                  *********  Making request to my API *********

        public async static Task<HttpResponseMessage> GetEngineById(int code)
        {
            using (HttpClient client = new HttpClient())
            {
                return await client.GetAsync(new Uri(Hooks.WebHostUri, $"/Moteur/GetEngineByCode/{code}")).ConfigureAwait(false);
            }
        }
        public async static Task<HttpResponseMessage> GetEngines()
        {
            using (HttpClient client = new HttpClient())
            {
                return await client.GetAsync(new Uri(Hooks.WebHostUri, $"/Moteur/GetAll/Engines")).ConfigureAwait(false);
            }
        }

        //                  *********  Converting from Table *********

        public static MyEngine GetEngineRequestFromTable(Table table)
        {
            MyEngine res = new MyEngine
            {
                Id = new ObjectId(table.Rows[0][1]),
                Code = int.Parse(table.Rows[0][2]),
                Name = table.Rows[0][3]

            };

            return res;
        }

        public static List<MyEngine> GetEnginesRequestFromTable(Table table)
        {
            var tableRead = new List<MyEngine>();

            foreach (var item in table.Rows)
            {
                tableRead.Add(new MyEngine
                {
                    Id = new ObjectId(item["Id"]),
                    Code = int.Parse(item["Code"]),
                    Name = item["Name"]



                });
            }

            return tableRead;
        }

        public static Task<MyEngine> GetEngineFromTable(Table table)
        {
            return Task.FromResult(new MyEngine
            {
                Id = new ObjectId("605dbf9f512f158a3ae3416c"),
                Code = 10,
                Name = "E-ticket"
                 
            });
        }

        //                  *********  Converting from HttpResponseMessage *********

        public static MyEngine GetEngineRequestFromResponse(HttpResponseMessage response)
        {
            var EmpResponse = response.Content.ReadAsStringAsync().Result;
            var EngineInfo = JsonConvert.DeserializeObject<MyEngine>(EmpResponse);

            return EngineInfo;
        }
        public static List<MyEngine> GetEnginesRequestFromResponse(HttpResponseMessage response)
        {
            var EmpResponse = response.Content.ReadAsStringAsync().Result;

            var EngineObj = JObject.Parse(EmpResponse);
            var EngineGuid = Convert.ToString(EngineObj["items"]);  // extracts json array which contains my list from my json object

            var EnginesInfo = JsonConvert.DeserializeObject<List<MyEngine>>(EngineGuid);

            return EnginesInfo;
        }


    }
}
