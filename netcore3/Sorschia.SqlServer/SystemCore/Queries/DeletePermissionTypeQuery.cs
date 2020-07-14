﻿using Sorschia.Data;
using Sorschia.SystemCore.Processes;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.SystemCore.Queries
{
    internal sealed class DeletePermissionTypeQuery
    {
        private const string PROCEDURE = "[SystemCore].[DeletePermissionType]";
        private const string PARAM_ID = "@Id";
        private const string PARAM_ISCASCADED = "@IsCascaded";
        private const int AFFECTEDROWS = 1;

        private readonly ISessionProvider _sessionProvider;

        public DeletePermissionTypeQuery(ISessionProvider sessionProvider)
        {
            _sessionProvider = sessionProvider;
        }

        public async Task<bool> ExecuteAsync(DeletePermissionTypeModel model, SqlConnection connection, SqlTransaction transaction, CancellationToken cancellationToken = default)
        {
            using var command = CreateCommand(model, connection, transaction);
            return await command.ExecuteNonQueryAsync(cancellationToken) == AFFECTEDROWS;
        }

        private SqlCommand CreateCommand(DeletePermissionTypeModel model, SqlConnection connection, SqlTransaction transaction) => connection
            .CreateProcedureCommand(PROCEDURE, transaction)
            .AddInParameter(PARAM_ID, model.Id)
            .AddInParameter(PARAM_ISCASCADED, model.IsCascaded)
            .AddSessionIdParameter(_sessionProvider);
    }
}