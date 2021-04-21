
using Engine.Domain.Abstractions.Dtos.Handlers;
using Engine.Domain.Models;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cds.Engine.Tests.ProviderPact
{
   
    public class InMemoryEngineRepository : IEngineRepository
    {
        [Obsolete]
        public Task<MyEngine> GetEngineById(int code)
        {
            var engine = new MyEngine
            {
                Id = new ObjectId(timestamp: 1617721631, machine: 7894647, pid: 13311, increment: 5403081),
                Code = 16,
                Name = "Beuate",
                IsEnable = true,
                SearchText = "string",
                Scopes = new List<Scope> { new Scope { ScopeId = 2, Name = "string", Order = 0, IsEnable = true } },
                InputFields = new List<InputField> { new InputField { InputId = 1, IsEnable = true, IsMandatory = true, Label = "string", Order = 0, Type = "string", Parameters = new List<Parameter> { new Parameter { ScopeParameterId = 1, ExternalCodeId = 0, Order = 0, Label = "string" } } } },
                BackGroundImages = new List<BackGroundImage> { new BackGroundImage { Alt = "string", IsEnable = true, OpenInNewTab = true, Order = 0, UrlImageDesktop = "string", UrlLinkDesktop = "string", UrlImageMobile = "string", UrlLinkMobile = "string" } },
                Logo = new List<Logo> { new Logo { UrlImageDesktop = "string", UrlLinkDesktop = "string", UrlImageMobile = "string", UrlLinkMobile = "string", Alt = "string", IsEnable = true, OpenInNewTab = true } },
                MarketingText = new List<MarketingText> { new MarketingText { IsEnable = true, Text = "string" } }
            };
            if (code == 16)
            {
                return Task.FromResult(engine);
            }

            else
            {
                return null;
            }
        }
        [Obsolete]
        public Task<List<MyEngine>> GetEngines()
        {
          List<MyEngine> engine = new List<MyEngine>
            {
                new  MyEngine{
               Id = new ObjectId(timestamp: 1617878829, machine: 15810591, pid:  -14883, increment: 1192671),
                Code = 16,
                Name = "Beaute",
                IsEnable = true,
                SearchText = "string",
                Scopes = new List<Scope> { new Scope { ScopeId = 2, Name = "string", Order = 0, IsEnable = true } },
                InputFields = new List<InputField> { new InputField { InputId = 3, IsEnable = true, IsMandatory = true, Label = "string", Order = 0, Type = "string", Parameters = new List<Parameter> { new Parameter { ScopeParameterId = 4, ExternalCodeId = 0, Order = 0, Label = "string" } } } },
                BackGroundImages = new List<BackGroundImage> { new BackGroundImage { Alt = "string", IsEnable = true, OpenInNewTab = true, Order = 0, UrlImageDesktop = "string", UrlLinkDesktop = "string", UrlImageMobile = "string", UrlLinkMobile = "string" } },
                Logo = new List<Logo> { new Logo { UrlImageDesktop = "string", UrlLinkDesktop = "string", UrlImageMobile = "string", UrlLinkMobile = "string", Alt = "string", IsEnable = true, OpenInNewTab = true } },
                MarketingText = new List<MarketingText> { new MarketingText { IsEnable = true, Text = "string" } }
            },
             new  MyEngine
             {
               Id = new ObjectId(timestamp: 1617883676, machine: 11034557, pid:  27952, increment: 7085875),
                 Code = 17,
                 Name = "Filme",
                 IsEnable = true,
                 SearchText = "string",
                Scopes = new List<Scope> { new Scope { ScopeId = 3, Name = "string", Order = 0, IsEnable = true } },
                InputFields = new List<InputField> { new InputField { InputId = 1, IsEnable = true, IsMandatory = true, Label = "string", Order = 0, Type = "string", Parameters = new List<Parameter> { new Parameter { ScopeParameterId = 2, ExternalCodeId = 0, Order = 0, Label = "string" } } } },
                BackGroundImages = new List<BackGroundImage> { new BackGroundImage { Alt = "string", IsEnable = true, OpenInNewTab = true, Order = 0, UrlImageDesktop = "string", UrlLinkDesktop = "string", UrlImageMobile = "string", UrlLinkMobile = "string" } },
                Logo = new List<Logo> { new Logo { UrlImageDesktop = "string", UrlLinkDesktop = "string", UrlImageMobile = "string", UrlLinkMobile = "string", Alt = "string", IsEnable = true, OpenInNewTab = true } },
                MarketingText = new List<MarketingText> { new MarketingText { IsEnable = true, Text = "string" } }
             }
             };
            return Task.FromResult(engine);
        }

        [Obsolete]
        public Task<ObjectId> CreateEngine(MyEngine moteur)
        {
          
          
            return Task.FromResult(new ObjectId(timestamp: 1617721631, machine: 7894647, pid: 13311, increment: 5403081));
        }

        [Obsolete]
        public Task<bool> GetEngineByCode(int code)
        {
            var engine = new MyEngine
            {
                Id = new ObjectId(timestamp: 1617721631, machine: 7894647, pid: 13311, increment: 5403081),
                Code = 16,
                Name = "Beuate",
                IsEnable = true,
                SearchText = "string",
                Scopes = new List<Scope> { new Scope { ScopeId = 2, Name = "string", Order = 0, IsEnable = true } },
                InputFields = new List<InputField> { new InputField { InputId = 1, IsEnable = true, IsMandatory = true, Label = "string", Order = 0, Type = "string", Parameters = new List<Parameter> { new Parameter { ScopeParameterId = 1, ExternalCodeId = 0, Order = 0, Label = "string" } } } },
                BackGroundImages = new List<BackGroundImage> { new BackGroundImage { Alt = "string", IsEnable = true, OpenInNewTab = true, Order = 0, UrlImageDesktop = "string", UrlLinkDesktop = "string", UrlImageMobile = "string", UrlLinkMobile = "string" } },
                Logo = new List<Logo> { new Logo { UrlImageDesktop = "string", UrlLinkDesktop = "string", UrlImageMobile = "string", UrlLinkMobile = "string", Alt = "string", IsEnable = true, OpenInNewTab = true } },
                MarketingText = new List<MarketingText> { new MarketingText { IsEnable = true, Text = "string" } }
            };
            if(engine.Code == code)
                return Task.FromResult(true);
            return Task.FromResult(false);

        }

        [Obsolete]
        public Task<bool> UpdateEngine(int code, MyEngine engine)
        {
            new MyEngine
            {
                Id = new ObjectId(timestamp: 1617721631, machine: 7894647, pid: 13311, increment: 5403081),
                Code = 16,
                Name = "Beuate",
                IsEnable = true,
                SearchText = "string",
                Scopes = new List<Scope> { new Scope { ScopeId = 2, Name = "string", Order = 0, IsEnable = true } },
                InputFields = new List<InputField> { new InputField { InputId = 1, IsEnable = true, IsMandatory = true, Label = "string", Order = 0, Type = "string", Parameters = new List<Parameter> { new Parameter { ScopeParameterId = 1, ExternalCodeId = 0, Order = 0, Label = "string" } } } },
                BackGroundImages = new List<BackGroundImage> { new BackGroundImage { Alt = "string", IsEnable = true, OpenInNewTab = true, Order = 0, UrlImageDesktop = "string", UrlLinkDesktop = "string", UrlImageMobile = "string", UrlLinkMobile = "string" } },
                Logo = new List<Logo> { new Logo { UrlImageDesktop = "string", UrlLinkDesktop = "string", UrlImageMobile = "string", UrlLinkMobile = "string", Alt = "string", IsEnable = true, OpenInNewTab = true } },
                MarketingText = new List<MarketingText> { new MarketingText { IsEnable = true, Text = "string" } }
            };
            if (engine.Code == code)
                return Task.FromResult(true);
            return Task.FromResult(false);

        }

        [Obsolete]
        public Task<bool> DeleteEngine(int code)
        {
            var engine = new MyEngine
            {
                Id = new ObjectId(timestamp: 1617721631, machine: 7894647, pid: 13311, increment: 5403081),
                Code = 16,
                Name = "Beuate",
                IsEnable = true,
                SearchText = "string",
                Scopes = new List<Scope> { new Scope { ScopeId = 2, Name = "string", Order = 0, IsEnable = true } },
                InputFields = new List<InputField> { new InputField { InputId = 1, IsEnable = true, IsMandatory = true, Label = "string", Order = 0, Type = "string", Parameters = new List<Parameter> { new Parameter { ScopeParameterId = 1, ExternalCodeId = 0, Order = 0, Label = "string" } } } },
                BackGroundImages = new List<BackGroundImage> { new BackGroundImage { Alt = "string", IsEnable = true, OpenInNewTab = true, Order = 0, UrlImageDesktop = "string", UrlLinkDesktop = "string", UrlImageMobile = "string", UrlLinkMobile = "string" } },
                Logo = new List<Logo> { new Logo { UrlImageDesktop = "string", UrlLinkDesktop = "string", UrlImageMobile = "string", UrlLinkMobile = "string", Alt = "string", IsEnable = true, OpenInNewTab = true } },
                MarketingText = new List<MarketingText> { new MarketingText { IsEnable = true, Text = "string" } }
            };
            if (engine.Code == code)
                return Task.FromResult(true);
            return Task.FromResult(false);
        }
    }
}