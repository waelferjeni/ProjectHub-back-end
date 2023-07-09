using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = Domain.Models.Task;

namespace Domain.DTOs
{
    public class UserStoryDTO
    {
        public string Description { get; set; }
        public string Name { get; set; }

        public int EstimatedDuration { get; set; }
        public DateTime StartDate { get; set; }
        public State UserStoryState { get; set; }
        public Guid ProjectId { get; set; }
        public Guid SprintId { get; set; }

    }
}
