﻿using MediatR;
using Microsoft.EntityFrameworkCore;
using Sorschia.Identity.Entities;
using System.Threading;
using System.Threading.Tasks;
using SystemBase.Entities.Exceptions.Builders;
using SystemBase.Extensions;

namespace Sorschia.Identity.Processes.Handlers
{
    internal sealed class DbInsertRoleHandler : IRequestHandler<DbInsertRole, Role>
    {
        public async Task<Role> Handle(DbInsertRole request, CancellationToken cancellationToken)
        {
            var context = request.TryGetContext();

            if (!string.IsNullOrEmpty(request.LookupCode) && await context.Roles.AnyAsync(_ => _.LookupCode == request.LookupCode, cancellationToken))
                throw new DuplicateEntityExceptionBuilder()
                    .WithEntityType<Role>()
                    .WithMessage("Role with same look-up code already exists")
                    .WithDebugMessage($"Role with LookupCode '{request.LookupCode}' already exists")
                    .AddField(nameof(Role.LookupCode), request.LookupCode)
                    .Build();

            if (await context.Roles.AnyAsync(_ => _.Name == request.Name, cancellationToken))
                throw new DuplicateEntityExceptionBuilder()
                    .WithEntityType<Role>()
                    .WithMessage("Role already exists")
                    .WithDebugMessage($"Role with Name '{request.Name}' already exists")
                    .AddField(nameof(Role.Name), request.Name)
                    .Build();

            var role = request.AsRole();
            context.Roles.AddWithFootprint(role);
            await context.SaveChangesAsync(cancellationToken);
            return role;
        }
    }
}
