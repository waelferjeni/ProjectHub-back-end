using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class TeamUserDTO
    {
        public Guid TeamId { get; set; }
        public Guid UserId { get; set; }
        public Role UserRole { get; set; }


    }
}
