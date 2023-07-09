using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class UserStory
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int EstimatedDuration { get; set; }
        public int DurationAvailable { get; set; }

        public UserStoryState UserStoryState { get; set; }
        public Guid ProjectId { get; set; }
        public Guid? SprintId { get; set; }
        public ICollection<Task>? Tasks { get; set; }

    }
    public enum UserStoryState
    {
        ToDo,
        InProgress,
        Done
    }
}
