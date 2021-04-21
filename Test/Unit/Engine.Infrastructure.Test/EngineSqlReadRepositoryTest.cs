using Dapper;
using Engine.Domain.Models;
using Moq;
using Moq.Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;
using Xunit;

namespace Engine.Infrastructure.Test
{
    public  class EngineSqlReadRepositoryTest
    {
        private readonly EngineSqlRepository _repository;
        private readonly Mock<DbConnection> _connectionMock;
        public EngineSqlReadRepositoryTest()
        {
            _connectionMock = new Mock<DbConnection>();
            _repository = new EngineSqlRepository(() => _connectionMock.Object);
        }
        [Fact]
        public async Task GetEngineAsync_WithValidRequest_ReturnsEngine()
        {
            //Data
            List<MyReadEngine> engines = FakeData.GetEngines();
            int Code = 1;

            //Arrange
            _connectionMock
                   .SetupDapperAsync(conn => conn.QueryAsync<MyReadEngine>(
                       It.IsAny<string>(),
                       new { EngineCode = Code },
                       null,
                       null,
                       CommandType.StoredProcedure))
                   .ReturnsAsync(engines);

            //Act
            var result = await _repository.GetEngineById(Code).ConfigureAwait(false);

            //Assert 
            Assert.NotNull(result);
            Assert.IsType<MyReadEngine>(result);
        }
    }
}
