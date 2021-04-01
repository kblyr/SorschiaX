﻿using System.Collections.Generic;

namespace Sorschia.Entities
{
    public class Application : ApplicationBase
    {
        public ICollection<Role> Roles { get; set; } = new List<Role>();
        public ICollection<Permission> Permissions { get; set; } = new List<Permission>();

        public const int NameMaxLength = 100;
        public const int DescriptionMaxLength = 500;
    }
}
