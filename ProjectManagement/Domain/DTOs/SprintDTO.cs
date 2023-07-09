using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class SprintDTO
    {
        public string? Name { get; set; }

        public string? Description { get; set; }
        public int estimatedDuration { get; set; }
        public DateTime startDate { get; set; }
        public State SprintState { get; set; }
        public Guid projectId { get; set; }
        public int DurationAvailable { get; set; }

    }
}
