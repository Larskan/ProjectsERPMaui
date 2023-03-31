using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Networking;
using ProjectsERPMaui.Model;
using ProjectsERPMaui.Services;
using ProjectsERPMaui.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectsERPMaui.ViewModel
{

    [QueryProperty(nameof(ProjList), nameof(ProjList))]
    public partial class ProjectViewModel : ObservableObject
    {

        [ObservableProperty]
        public ObservableCollection<Project> _projList; 

        [ObservableProperty]
        public Project _proj;

        DynamicsService dynamicsService;
        /// <summary>
        /// Constructor that initializes
        /// </summary>
        public ProjectViewModel() 
        {
            ProjList = new ObservableCollection<Project>();
            dynamicsService = new DynamicsService();
        }

        /// <summary>
        /// switches to Task page and converts the tasklist 
        /// to an ObservableCollection and send it to the TaskViewModel
        /// </summary>
        /// <param name="proj"></param>
        [RelayCommand]
        //Takes Project object and creates new ObservableCollection from TaskList of Project object
        //Then navigates to Task page using GoToAsync
        async void GoToTaskPage(Project proj)
        {

            ObservableCollection<ProjectTask> Convert = new ObservableCollection<ProjectTask>(proj.TaskList);
            await Shell.Current.GoToAsync("//Task", new Dictionary<string, object>
            {
                //Objects passed to Task Page
                ["Proj"] = proj,
                ["ProjTaskList"] = Convert
            });
        }
    }
}
