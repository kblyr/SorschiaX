﻿using Sorschia.Processes;
using Sorschia.SystemCore.Entities;
using System.Collections.Generic;

namespace Sorschia.SystemCore.Processes
{
    public interface ISearchPermission : IAsyncProcess<SearchPermissionResult>
    {
        SearchPermissionModel Model { get; set; }
    }

    public sealed class SearchPermissionModel : PaginationModel
    {
        public string FilterText { get; set; }
        public bool? IsApiPermission { get; set; }
        public bool? IsDatabasePermission { get; set; }
        public IList<int> GroupIds { get; set; } = new List<int>();
        public IList<int> SkippedIds { get; set; } = new List<int>();
        public IList<int> UserIds { get; set; } = new List<int>();
    }

    public sealed class SearchPermissionResult : PaginationResult
    {
        public IList<Permission> Permissions { get; set; } = new List<Permission>();
    }
}
