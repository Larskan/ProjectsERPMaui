﻿using CommunityToolkit.Mvvm.ComponentModel;
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
    [QueryProperty(nameof(ProjTaskList), nameof(ProjTaskList))]

    public partial class TaskViewModel : ObservableObject
    {
        [ObservableProperty]
        ObservableCollection<ProjectTask> _projTaskList;

        [ObservableProperty]
        public Project _proj;

        public TaskViewModel()
        {
            Proj = new Project();
            ProjTaskList = new ObservableCollection<ProjectTask>();          
        }

        /// <summary>
        /// goes to the Pomodoro page and sends the silected Pomodoro to the side
        /// </summary>
        /// <param name="projTask"></param>
        [RelayCommand]
        public async void GoToPomodoroPage(ProjectTask projTask) 
        {
            await Shell.Current.GoToAsync("//Pomo", new Dictionary<string, object>
            {
                ["ProjTask"] = projTask
            });
        }
    }
}
