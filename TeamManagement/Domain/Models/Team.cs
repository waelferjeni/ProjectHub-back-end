﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Team
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid ServiceId { get; set; }
        public ICollection<TeamUser>? TeamUsers { get; set; }
    }
}
