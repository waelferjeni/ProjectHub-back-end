using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Project
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? ClientName { get; set; }
        public int EstimatedDuration { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? Description { get; set; }
        public State ProjectState { get; set; }
        public ICollection<Sprint>? Sprints { get; set; }
        public Guid Fk_ServiceId { get; set; }
        public Service? Service { get; set; }
        public Guid TeamId { get; set;}
        public Guid ProjectLeaderId { get; set; }
    }
    public enum State
    {
        ToDo,
        InProgress,
        Done,
        Validated
    }
}
