﻿namespace Sorschia.Entities
{
    public interface IUserApplication
    {
        long Id { get; set; }
        int UserId { get; set; }
        int ApplicationId { get; set; }
    }
}
