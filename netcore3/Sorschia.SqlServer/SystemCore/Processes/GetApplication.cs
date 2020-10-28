﻿using Sorschia.Data;
using Sorschia.SystemCore.Entities;
using Sorschia.SystemCore.Queries;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.SystemCore.Processes
{
    internal sealed class GetApplication : ProcessBase, IGetApplication
    {
        private readonly GetApplicationQuery _query;

        public int Id { get; set; }

        public GetApplication(IConnectionStringProvider connectionStringProvider, GetApplicationQuery query) : base(connectionStringProvider)
        {
            _query = query;
        }

        public async Task<Application> ExecuteAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var id = Id;
                using var connection = await OpenConnectionAsync(cancellationToken);
                return await _query.ExecuteAsync(id, connection, default, cancellationToken);
            }
            catch (Exception ex)
            {
                ThrowError(ex);
                return default;
            }
        }
    }
}
