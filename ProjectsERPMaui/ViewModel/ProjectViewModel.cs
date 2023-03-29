using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Networking;
using ProjectsERPMaui.Model;
using ProjectsERPMaui.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectsERPMaui.ViewModel
{
    [QueryProperty(nameof(Project), nameof(Project))]
    [QueryProperty(nameof(Projects), nameof(Projects))]
    public partial class ProjectViewModel : ObservableObject
    {
        [ObservableProperty]
        public ObservableCollection<Project> _projects; 

        [ObservableProperty]
        public Project _project;
        public ProjectViewModel() 
        {
            Projects = new ObservableCollection<Project>();
                       
        }

        [RelayCommand]
        public async void GoToTaskPage()
        {
            await Shell.Current.GoToAsync("//Task");
        }
    }
}
