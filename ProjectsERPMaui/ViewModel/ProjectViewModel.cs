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
    public partial class ProjectViewModel : ObservableObject
    {
        public ObservableCollection<Project> Projects { get; } = new ObservableCollection<Project>();

        public ProjectViewModel() 
        {
            Projects.Add(new Project()
            {
                ProjectName = "Test1",
                ProjectID = 1,
                TotalTime = 100,
                RemainingTime = 100,
            });

            Projects.Add(new Project()
            {
                ProjectName = "Test2",
                ProjectID = 2,
                TotalTime = 80,
                RemainingTime = 60,
            });
        }

        [RelayCommand]
        public async void GoToTaskPage()
        {
            await Shell.Current.GoToAsync("//Task");
        }
    }
}
