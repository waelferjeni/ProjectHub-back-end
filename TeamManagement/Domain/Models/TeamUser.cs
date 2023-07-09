﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class TeamUser
    {
        public Guid TeamId { get; set; }
        public Team? Team { get; set; }
        public Guid UserId { get; set; }
        public Role UserRole { get; set; }
    }
    public enum Role
    {
        Employee,
        ProjectLeader
    }
}
