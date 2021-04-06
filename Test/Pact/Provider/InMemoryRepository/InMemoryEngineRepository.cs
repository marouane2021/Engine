
using Engine.Domain.Abstractions.Dtos.Handlers;
using Engine.Domain.Models;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cds.OfferComparatorUpdatesReader.InMemoryRepository
{
    /// <summary>
    /// InMemory CompetingOffer Changes Repository
    /// </summary>
    public class InMemoryEngineRepository : IEngineRepository
    {
        /// <summary>
        /// Gets the competing offer changes.
        /// </summary>
        /// <param name="sellerId">The seller identifier.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<MyEngine> GetEngineById(int code)
        {
            var engine = new MyEngine
            {
                Id = "6048d0b57757e1f98eb48273",
                Code = 2,
                Name = "beaute",
                IsEnable = true,
                SearchText = "hello",
                Scopes = new List<Scope> { new Scope { ScopeId = 16, Name = "sc", Order = 5, IsEnable = true } },
                InputFields = new List<InputField> { new InputField { InputId = 56, IsEnable = true, IsMandatory = true, Label = "beauté", Order = 5, Type = "input", Parameters = new List<Parameter> { new Parameter { ScopeParameterId = 668, ExternalCodeId = 666, Order = 9, Label = "Parameter" } } } },
                BackGroundImages = new List<BackGroundImage> { new BackGroundImage { Alt = "pic", IsEnable = true, OpenInNewTab = true, Order = 7, UrlImageDesktop = "htttpkf", UrlLinkDesktop = "iioloo", UrlImageMobile = "jhmùhù", UrlLinkMobile = "iomom" } },
                Logo = new List<Logo> { new Logo { UrlImageDesktop = "htrrttpkf", UrlLinkDesktop = "iigtgoloo", UrlImageMobile = "jhmrggtrgù", UrlLinkMobile = "igtgtomom", Alt = "logo", IsEnable = true, OpenInNewTab = true } },
                MarketingText = new List<MarketingText> { new MarketingText { IsEnable = true, Text = "marketing" } }
            };
            if (code == engine.Code)
            {
                return Task.FromResult(engine);

            }

            else
            {
                throw new NotImplementedException();

            }
        }

        /// <summary>
        /// Sets the offer change as read.
        /// </summary>
        /// <param name="sellerId">The seller identifier.</param>
        /// <param name="updatedProductOffer">The updated product offer.</param>
        /// <returns></returns>
        public Task<List<MyEngine>> GetEngines()
        {
          List<MyEngine> engine = new List<MyEngine>
            {
                new  MyEngine{
                Id = "6048d0b57757e1f98eb48273",
                Code = 1,
                Name = "beaute",
                IsEnable = true,
                SearchText = "hello",
                Scopes = new List<Scope> { new Scope { ScopeId = 16, Name = "sc", Order = 5, IsEnable = true } },
                InputFields = new List<InputField> { new InputField { InputId = 56, IsEnable = true, IsMandatory = true, Label = "beauté", Order = 5, Type = "input", Parameters = new List<Parameter> { new Parameter { ScopeParameterId = 668, ExternalCodeId = 666, Order = 9, Label = "Parameter" } } } },
                BackGroundImages = new List<BackGroundImage> { new BackGroundImage { Alt = "pic", IsEnable = true, OpenInNewTab = true, Order = 7, UrlImageDesktop = "htttpkf", UrlLinkDesktop = "iioloo", UrlImageMobile = "jhmùhù", UrlLinkMobile = "iomom" } },
                Logo = new List<Logo> { new Logo { UrlImageDesktop = "htrrttpkf", UrlLinkDesktop = "iigtgoloo", UrlImageMobile = "jhmrggtrgù", UrlLinkMobile = "igtgtomom", Alt = "logo", IsEnable = true, OpenInNewTab = true } },
                MarketingText = new List<MarketingText> { new MarketingText { IsEnable = true, Text = "marketing" } }
            },
             new  MyEngine
             {
                 Id = "6048d0b57757e1f98eb48253",
                 Code = 12,
                 Name = "alimentation",
                 IsEnable = true,
                 SearchText = "hello",
                 Scopes = new List<Scope> { new Scope { ScopeId = 16, Name = "sc", Order = 5, IsEnable = true } },
                 InputFields = new List<InputField> { new InputField { InputId = 56, IsEnable = true, IsMandatory = true, Label = "beauté", Order = 5, Type = "input", Parameters = new List<Parameter> { new Parameter { ScopeParameterId = 668, ExternalCodeId = 666, Order = 9, Label = "Parameter" } } } },
                 BackGroundImages = new List<BackGroundImage> { new BackGroundImage { Alt = "pic", IsEnable = true, OpenInNewTab = true, Order = 7, UrlImageDesktop = "htttpkf", UrlLinkDesktop = "iioloo", UrlImageMobile = "jhmùhù", UrlLinkMobile = "iomom" } },
                 Logo = new List<Logo> { new Logo { UrlImageDesktop = "htrrttpkf", UrlLinkDesktop = "iigtgoloo", UrlImageMobile = "jhmrggtrgù", UrlLinkMobile = "igtgtomom", Alt = "logo", IsEnable = true, OpenInNewTab = true } },
                 MarketingText = new List<MarketingText> { new MarketingText { IsEnable = true, Text = "marketing" } }
             }
             };
            return Task.FromResult(engine);
        }

        public Task<ObjectId> CreateEngine(MyEngine moteur)
        {
           new MyEngine
            {

                Id = "6048d0b57757e1f98eb48273",
                Code = 2,
                Name = "beaute",
                IsEnable = true,
                SearchText = "hello",
                Scopes = new List<Scope> { new Scope { ScopeId = 16, Name = "sc", Order = 5, IsEnable = true } },
                InputFields = new List<InputField> { new InputField { InputId = 56, IsEnable = true, IsMandatory = true, Label = "beauté", Order = 5, Type = "input", Parameters = new List<Parameter> { new Parameter { ScopeParameterId = 668, ExternalCodeId = 666, Order = 9, Label = "Parameter" } } } },
                BackGroundImages = new List<BackGroundImage> { new BackGroundImage { Alt = "pic", IsEnable = true, OpenInNewTab = true, Order = 7, UrlImageDesktop = "htttpkf", UrlLinkDesktop = "iioloo", UrlImageMobile = "jhmùhù", UrlLinkMobile = "iomom" } },
                Logo = new List<Logo> { new Logo { UrlImageDesktop = "htrrttpkf", UrlLinkDesktop = "iigtgoloo", UrlImageMobile = "jhmrggtrgù", UrlLinkMobile = "igtgtomom", Alt = "logo", IsEnable = true, OpenInNewTab = true } },
                MarketingText = new List<MarketingText> { new MarketingText { IsEnable = true, Text = "marketing" } }

            };
            return Task.FromResult((new ObjectId(moteur.Id)));
        }

        public Task<bool> GetEngineByCode(int code)
        {
            var engine = new MyEngine
            {
                Id = "6048d0b57757e1f98eb48273",
                Code = 2,
                Name = "beaute",
                IsEnable = true,
                SearchText = "hello",
                Scopes = new List<Scope> { new Scope { ScopeId = 16, Name = "sc", Order = 5, IsEnable = true } },
                InputFields = new List<InputField> { new InputField { InputId = 56, IsEnable = true, IsMandatory = true, Label = "beauté", Order = 5, Type = "input", Parameters = new List<Parameter> { new Parameter { ScopeParameterId = 668, ExternalCodeId = 666, Order = 9, Label = "Parameter" } } } },
                BackGroundImages = new List<BackGroundImage> { new BackGroundImage { Alt = "pic", IsEnable = true, OpenInNewTab = true, Order = 7, UrlImageDesktop = "htttpkf", UrlLinkDesktop = "iioloo", UrlImageMobile = "jhmùhù", UrlLinkMobile = "iomom" } },
                Logo = new List<Logo> { new Logo { UrlImageDesktop = "htrrttpkf", UrlLinkDesktop = "iigtgoloo", UrlImageMobile = "jhmrggtrgù", UrlLinkMobile = "igtgtomom", Alt = "logo", IsEnable = true, OpenInNewTab = true } },
                MarketingText = new List<MarketingText> { new MarketingText { IsEnable = true, Text = "marketing" } }
            };
            if(engine.Code == code)
                return Task.FromResult(true);
            return Task.FromResult(false);

        }

        public Task<bool> UpdateEngine(int code, MyEngine engine)
        {
            new MyEngine
            {
                Id = "6048d0b57757e1f98eb48273",
                Code = 2,
                Name = "beaute",
                IsEnable = true,
                SearchText = "hello",
                Scopes = new List<Scope> { new Scope { ScopeId = 16, Name = "sc", Order = 5, IsEnable = true } },
                InputFields = new List<InputField> { new InputField { InputId = 56, IsEnable = true, IsMandatory = true, Label = "beauté", Order = 5, Type = "input", Parameters = new List<Parameter> { new Parameter { ScopeParameterId = 668, ExternalCodeId = 666, Order = 9, Label = "Parameter" } } } },
                BackGroundImages = new List<BackGroundImage> { new BackGroundImage { Alt = "pic", IsEnable = true, OpenInNewTab = true, Order = 7, UrlImageDesktop = "htttpkf", UrlLinkDesktop = "iioloo", UrlImageMobile = "jhmùhù", UrlLinkMobile = "iomom" } },
                Logo = new List<Logo> { new Logo { UrlImageDesktop = "htrrttpkf", UrlLinkDesktop = "iigtgoloo", UrlImageMobile = "jhmrggtrgù", UrlLinkMobile = "igtgtomom", Alt = "logo", IsEnable = true, OpenInNewTab = true } },
                MarketingText = new List<MarketingText> { new MarketingText { IsEnable = true, Text = "marketing" } }
            };
            if (engine.Code == code)
                return Task.FromResult(true);
            return Task.FromResult(false);
        }

        public Task<bool> DeleteEngine(int code)
        {
           var engine =  new MyEngine
            {
                Id = "6048d0b57757e1f98eb48273",
                Code = 2,
                Name = "beaute",
                IsEnable = true,
                SearchText = "hello",
                Scopes = new List<Scope> { new Scope { ScopeId = 16, Name = "sc", Order = 5, IsEnable = true } },
                InputFields = new List<InputField> { new InputField { InputId = 56, IsEnable = true, IsMandatory = true, Label = "beauté", Order = 5, Type = "input", Parameters = new List<Parameter> { new Parameter { ScopeParameterId = 668, ExternalCodeId = 666, Order = 9, Label = "Parameter" } } } },
                BackGroundImages = new List<BackGroundImage> { new BackGroundImage { Alt = "pic", IsEnable = true, OpenInNewTab = true, Order = 7, UrlImageDesktop = "htttpkf", UrlLinkDesktop = "iioloo", UrlImageMobile = "jhmùhù", UrlLinkMobile = "iomom" } },
                Logo = new List<Logo> { new Logo { UrlImageDesktop = "htrrttpkf", UrlLinkDesktop = "iigtgoloo", UrlImageMobile = "jhmrggtrgù", UrlLinkMobile = "igtgtomom", Alt = "logo", IsEnable = true, OpenInNewTab = true } },
                MarketingText = new List<MarketingText> { new MarketingText { IsEnable = true, Text = "marketing" } }
            };
            if (engine.Code == code)
                return Task.FromResult(true);
            return Task.FromResult(false);
        }
    }
}