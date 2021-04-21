using Cds.Foundation.Test.Pact.Consumer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cds.Engine.Tests.ConsumerPact.EPConsumerTest
{
    public class EngineEpConsumer :BaseConsumer
    {
        public EngineEpConsumer() : base(new Uri("http://a01pacbro.cdweb.biz/"), "EngineEp", "EngineEpConsumerConsumer", "master", true) { }
    }

}

