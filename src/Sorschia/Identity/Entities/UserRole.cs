﻿namespace Sorschia.Identity.Entities
{
    public class UserRole : UserRoleBase
    {
        public User User { get; set; }
        public Role Role { get; set; }
    }
}