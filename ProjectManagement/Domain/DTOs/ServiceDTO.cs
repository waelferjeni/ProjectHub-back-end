using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class ServiceDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid ResponsableServiceID { get; set; }
    }
}
