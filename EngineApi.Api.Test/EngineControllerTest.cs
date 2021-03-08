using Engine.Domain.Abstractions;
using EngineApi.Api.Controllers.MoteurTestController;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace EngineApi.Api.Test
{
    public class EngineControllerTest
    {
        protected readonly Mock<ILogger<EngineController>> _mockLogger;
        protected readonly Mock<IEngineHandler> _mockEngineHandler;
        protected readonly Mock<IEngineRepository> _mockRepository;
        protected readonly EngineController engineController;

        public EngineControllerTest()
        {
            _mockLogger = new Mock<ILogger<EngineController>>();
            _mockEngineHandler = new Mock<IEngineHandler>();
            _mockRepository = new Mock<IEngineRepository>();
           engineController = new EngineController(_mockLogger.Object, _mockEngineHandler.Object, _mockRepository.Object);
        }

        [Fact]
        public void CreateEngine_WithId_ThrowsExceptionAsync()
        {

        }
    }
}
