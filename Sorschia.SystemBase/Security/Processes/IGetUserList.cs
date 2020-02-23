﻿using Sorschia.SystemBase.Security.Entities;
using System.Collections.Generic;

namespace Sorschia.SystemBase.Security.Processes
{
    public interface IGetUserList : IAsyncProcess<GetUserListResult>
    {
        GetUserListModel Model { get; set; }
    }

    public sealed class GetUserListModel : PaginatedModel
    {
        public string FilterText { get; set; }
        public IList<int> SkippedIdList { get; set; } = new List<int>();
    }

    public sealed class GetUserListResult : PaginatedResult
    {
        public IList<SystemUser> UserList { get; set; } = new List<SystemUser>();
    }
}