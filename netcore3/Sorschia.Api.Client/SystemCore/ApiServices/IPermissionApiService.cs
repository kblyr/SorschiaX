﻿using Refit;
using Sorschia.SystemCore.Entities;
using Sorschia.SystemCore.Processes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sorschia.SystemCore.ApiServices
{
    public interface IPermissionApiService
    {
        [Delete(ApiServicePaths.Empty)]
        [Headers(ApiConstants.JwtAuthorizationHeader)]
        Task<bool> Delete([Body] DeletePermissionModel model);

        [Get(ApiServicePaths.Empty)]
        [Headers(ApiConstants.JwtAuthorizationHeader)]
        Task<Permission> Get(int id);

        [Get(ApiServicePaths.SystemCore.Permission.ApiPermission)]
        [Headers(ApiConstants.JwtAuthorizationHeader)]
        Task<ApiPermission> GetApiPermission(int id);

        [Post(ApiServicePaths.Empty)]
        [Headers(ApiConstants.JwtAuthorizationHeader)]
        Task<SavePermissionResult> Save([Body] SavePermissionModel model);

        [Post(ApiServicePaths.SystemCore.Permission.ApiPermission)]
        [Headers(ApiConstants.JwtAuthorizationHeader)]
        Task<SaveApiPermissionResult> SaveApiPermission([Body] SaveApiPermissionModel model);

        [Get(ApiServicePaths.Search)]
        [Headers(ApiConstants.JwtAuthorizationHeader)]
        Task<SearchPermissionResult> Search([Query] SearchPermissionModel model,
            [Query(CollectionFormat.Multi)] IList<int> typeIds,
            [Query(CollectionFormat.Multi)] IList<int> groupIds,
            [Query(CollectionFormat.Multi)] IList<int> skippedIds);
    }
}
