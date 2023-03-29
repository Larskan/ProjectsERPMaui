using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectsERPMaui.Model
{
    public partial class Employee : ObservableObject
    {
        public int EmpID { get; set; }
<<<<<<< HEAD
        public string Firstname { get; set; }
        public string Lastname { get; set; }
=======
        public string FirstName { get; set; }
        public string LastName { get; set; }
>>>>>>> 6807885ae19d1dbe1846aa3509d4314567bab109
        public bool Boolean { get; set; }
    }
}
