using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectsERPMaui.Model
{
    public class Project
    {
        public int ProjectID { get; set; }
        public string ProjectName { get; set; }
        public int TotalTime { get; set; }
        public int RemainingTime { get; set; }
    }
}
