using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectsERPMaui.Model
{
    public class Project
    {
        public int? ProjectID { get; set; }
        public string? ProjectName { get; set; }
        public List<ProjectTask>? taskList { get; set; }
    }
}
