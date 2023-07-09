using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class TaskDTO
    {
        public string Description { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public int EstimatedDuration { get; set; }
        public Guid UserStoryId { get; set; }
        public Guid EmployeeId { get; set; }


    }
}
