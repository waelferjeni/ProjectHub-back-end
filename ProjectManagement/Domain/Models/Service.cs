using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Service
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<Project>? Projects { get; set; }
        public Guid ServiceLeaderID { get; set; }
    }
}
 