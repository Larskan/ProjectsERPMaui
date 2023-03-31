using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectsERPMaui.Model
{
    public class ProjectTask
    {
        public int? taskID { get; set; }
        public int? projectID { get; set; }
        public string? taskName { get; set; }
        public string? description { get; set; }
        public decimal totalTimeUsed { get; set; }
        public int taskPlanTime { get; set; }
        public bool taskStatus { get; set; }

    }
}
