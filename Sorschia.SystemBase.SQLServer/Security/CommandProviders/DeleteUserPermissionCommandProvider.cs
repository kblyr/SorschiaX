﻿using Sorschia.SystemBase.Security.ParameterProviders;
using System.Data.SqlClient;

namespace Sorschia.SystemBase.Security.CommandProviders
{
    internal sealed class DeleteUserPermissionCommandProvider
    {
        public DeleteUserPermissionCommandProvider(ICurrentUserProvider currentUserProvider, DeleteUserPermissionParameterProvider parameterProvider)
        {
            _currentUserProvider = currentUserProvider;
            _parameterProvider = parameterProvider;
        }

        private readonly ICurrentUserProvider _currentUserProvider;
        private readonly DeleteUserPermissionParameterProvider _parameterProvider;

        public SqlCommand Get(long id, SqlConnection connection, SqlTransaction transaction) =>
            connection.CreateProcedureCommand(StoredProcedures.Security.DeleteUserPermission, transaction)
            .AddInParameter(_parameterProvider.Id, id)
            .AddInParameter(_parameterProvider.DeletedBy, _currentUserProvider.GetUsername());
    }
}