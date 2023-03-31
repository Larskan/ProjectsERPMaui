using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectsERPMaui.Model
{
    public class ProjectTask
    {
        public int? TaskID { get; set; }
        public int? ProjectID { get; set; }
        public string? TaskName { get; set; }
        public string? Description { get; set; }
        public double TimeUsed { get; set; }
        public int PlanTime { get; set; }
        
    }
}
