using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Sprint
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public int DurationAvailable { get; set; }
        public int estimatedDuration { get; set; }
        public string? Description { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public StateSprint SprintState { get; set; }
        public Guid projectId { get; set; }
        public Project? Project { get; set; }
    }

    public enum StateSprint
    {
        ToDo,
        InProgress,
        Done
    }
}
