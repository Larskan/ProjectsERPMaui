using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProjectsERPMaui.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectsERPMaui.ViewModel
{
    [QueryProperty(nameof(Proj), nameof(Proj))]
    [QueryProperty(nameof (TaskList), nameof(TaskList))]

    public partial class TaskViewModel : ObservableObject
    {
        [ObservableProperty]
        ObservableCollection<ProjectTask> _projTaskList;


        [ObservableProperty]
        List<ProjectTask> _taskList;

        [ObservableProperty]
        public Project _proj;

        public TaskViewModel()
        {
            Proj = new Project();
            TaskList = new List<ProjectTask>();
            ProjTaskList = new ObservableCollection<ProjectTask>(TaskList);          
        }

        [RelayCommand]
        public async void GoToLoginPage()
        {
            await Shell.Current.GoToAsync(nameof(View.LoginView));
        }

        [RelayCommand]
        public async void GoToPomodoroPage() 
        {
            await Shell.Current.GoToAsync("//Start");
        }
    }
}
