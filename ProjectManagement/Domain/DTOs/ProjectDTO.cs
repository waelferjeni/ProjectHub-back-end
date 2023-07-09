using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class ProjectDTO
    {
        public string? Name { get; set; }
        public string? ClientName { get; set; }
        public int EstimatedDuration { get; set; }
        public DateTime StartDate { get; set; }
        public string? Description { get; set; }
        public State ProjectState { get; set; }
        public Guid Fk_ServiceId { get; set; }
        public Guid TeamId { get; set; }
        public Guid ProjectLeaderId { get; set; }

    }
}
