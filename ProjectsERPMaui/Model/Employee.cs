﻿using CommunityToolkit.Mvvm.ComponentModel;
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
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public bool Boolean { get; set; }
    }
}
