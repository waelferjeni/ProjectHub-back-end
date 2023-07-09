using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Task
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int estimatedDuration { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public State taskState { get; set; }
        public int Complexity { get; set; }
        public Guid userStoryId { get; set; }
        public Guid employeeId { get; set; }
        public UserStory? UserStory { get; set; }
        public Guid projectId { get; set; }
        public Guid sprintId { get; set; }
    }


}
