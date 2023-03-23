using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectsERPMaui.Model
{
    public class ProjectTask
    {
        public int ProjectTaskID { get; set; }
        public int ProjectID { get; set; }
        public string TaskName { get; set; }
        public int TimeUsed { get; set; }
        public int PlanTime { get; set; }

    }
}
