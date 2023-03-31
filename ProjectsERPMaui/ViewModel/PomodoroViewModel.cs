using CommunityToolkit.Mvvm.ComponentModel;
using ProjectsERPMaui.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectsERPMaui.ViewModel
{
    [QueryProperty(nameof(ProjTask),nameof(ProjTask))]
    public partial class PomodoroViewModel : ObservableObject
    {
        [ObservableProperty]
        public ProjectTask _projTask;
        public PomodoroViewModel() 
        {
            ProjTask = new ProjectTask();
        }
    }
}
