﻿using Sorschia.Data;
using Sorschia.SystemCore.Processes;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.SystemCore.Queries
{
    internal sealed class DeleteModuleQuery
    {
        private const string PROCEDURE = "[SystemCore].[DeleteModule]";
        private const string PARAM_ID = "@Id";
        private const string PARAM_ISCASCADED = "@IsCascaded";

        private readonly ISessionIdProvider _sessionIdProvider;

        public DeleteModuleQuery(ISessionIdProvider sessionIdProvider)
        {
            _sessionIdProvider = sessionIdProvider;
        }

        public async Task<bool> ExecuteAsync(DeleteModuleModel model, SqlConnection connection, SqlTransaction transaction, CancellationToken cancellationToken = default)
        {
            using var command = CreateCommand(model, connection, transaction);
            await command.ExecuteNonQueryAsync(cancellationToken);
            return true;
        }

        private SqlCommand CreateCommand(DeleteModuleModel model, SqlConnection connection, SqlTransaction transaction) => connection
            .CreateProcedureCommand(PROCEDURE, transaction)
            .AddInParameter(PARAM_ID, model.Id)
            .AddInParameter(PARAM_ISCASCADED, model.IsCascaded)
            .AddSessionIdParameter(_sessionIdProvider);
    }
}
