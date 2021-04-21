using Dapper;
using Engine.Domain.Abstractions.Dtos;
using Engine.Domain.Models;
using System;
using System.Data;
using System.Threading.Tasks;


namespace Engine.Infrastructure
{
    public class EngineSqlRepository : IReadEngineRepository
    {
        private readonly Func<IDbConnection> _connectionFactory;
        public EngineSqlRepository(Func<IDbConnection> connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<MyReadEngine> GetEngineById(int code)
        {
            using (var connection = _connectionFactory())
            {
                MyReadEngine engineResult = await connection.QueryFirstOrDefaultAsync<MyReadEngine>(
                    StoredProcedures.GetEngineByCode,
                    new { code },
                    commandType: CommandType.StoredProcedure
                ).ConfigureAwait(false);
                return engineResult;
            }

        }
    }
}
