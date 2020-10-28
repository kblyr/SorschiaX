﻿using Sorschia.Data;
using Sorschia.SystemCore.Entities;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.SystemCore.Queries
{
    internal sealed class SavePermissionQuery
    {
        private const string PROCEDURE = "[SystemCore].[SavePermission]";
        private const string PARAM_ID = "@Id";
        private const string PARAM_DESCRIPTION = "@Description";
        private const string PARAM_GROUPID = "@GroupId";
        private const string PARAM_ISAPIPERMISSION = "@IsApiPermission";
        private const string PARAM_APIDOMAIN = "@ApiDomain";
        private const string PARAM_APICONTROLLER = "@ApiController";
        private const string PARAM_APIACTION = "@ApiAction";
        private const string PARAM_ISDATABASEPERMISSION = "@IsDatabasePermission";
        private const string PARAM_DATABASESCHEMA = "@DatabaseSchema";
        private const string PARAM_DATABASEPROCEDURE = "@DatabaseProcedure";

        private readonly ISessionIdProvider _sessionIdProvider;

        public SavePermissionQuery(ISessionIdProvider sessionIdProvider)
        {
            _sessionIdProvider = sessionIdProvider;
        }

        public async Task<Permission> ExecuteAsync(Permission permission, SqlConnection connection, SqlTransaction transaction, CancellationToken cancellationToken = default)
        {
            using var command = CreateCommand(permission, connection, transaction);
            await command.ExecuteNonQueryAsync(cancellationToken);
            permission.Id = command.Parameters.GetInt32(PARAM_ID);
            return permission.Id != 0 ? permission : null;
        }

        private SqlCommand CreateCommand(Permission permission, SqlConnection connection, SqlTransaction transaction) => connection
            .CreateProcedureCommand(PROCEDURE, transaction)
            .AddInOutParameter(PARAM_ID, permission.Id, SqlDbType.Int)
            .AddInParameter(PARAM_DESCRIPTION, permission.Description)
            .AddInParameter(PARAM_GROUPID, permission.GroupId)
            .AddSessionIdParameter(_sessionIdProvider)
            .AddInParameter(PARAM_ISAPIPERMISSION, permission.IsApiPermission)
            .AddInParameter(PARAM_APIDOMAIN, permission.ApiDomain)
            .AddInParameter(PARAM_APICONTROLLER, permission.ApiController)
            .AddInParameter(PARAM_APIACTION, permission.ApiAction)
            .AddInParameter(PARAM_ISDATABASEPERMISSION, permission.IsDatabasePermission)
            .AddInParameter(PARAM_DATABASESCHEMA, permission.DatabaseSchema)
            .AddInParameter(PARAM_DATABASEPROCEDURE, permission.DatabaseProcedure);
    }
}
