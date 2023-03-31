using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Graphics.Text;
using Newtonsoft.Json.Linq;
using ProjectsERPMaui.Model;
using ProjectsERPMaui.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProjectsERPMaui.ViewModel
{
    [QueryProperty(nameof(ProjTask),nameof(ProjTask))]
    public partial class PomodoroViewModel : ObservableObject
    {
        DynamicsService dynamicsService;

        public TimeOnly time;

        public double number;

        [ObservableProperty]
        string _timerText;

        public bool isRunning;

        [ObservableProperty]
        public ProjectTask _projTask;
        public PomodoroViewModel() 
        {
            ProjTask = new ProjectTask();
            dynamicsService = new DynamicsService();
            time = new TimeOnly();
            TimerText = $"{time.Minute}:{time.Second:00}";
        }

        /// <summary>
        /// starts the pomodoro timer
        /// </summary>
        [RelayCommand]
        public async void StartPomo()
        {
            isRunning = true;
            while (isRunning) 
            {
                time = time.Add(TimeSpan.FromSeconds(1));
                SetTime();
                await Task.Delay(TimeSpan.FromSeconds(1));
            }
        }

        /// <summary>
        /// set teh timer to pause
        /// </summary>
        [RelayCommand]
        public void PausePomo() 
        {
            isRunning = false;
        }

        /// <summary>
        /// stops the pomodoro session and send the used time until now
        /// </summary>
        [RelayCommand]
        public async void StopPomo() 
        {
            try
            {
                if (Double.TryParse(TimerText, out number))
                {
                    ProjTask.TimeUsed += number;
                }
                //bool check = await dynamicsService.UpdateTasks(ProjTask);
                if (true)
                {
                    isRunning = false;
                    time = new TimeOnly();
                    SetTime();
                }
                else
                {
                    //await Shell.Current.DisplayAlert("No Update", "sorry", "OK");
                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
            }

        }

        /// <summary>
        /// closes the task and updates the used time until now
        /// </summary>
        [RelayCommand]
        public async void SendPomo() 
        {
            try
            {
                if (!isRunning)
                {
                    if (Double.TryParse(TimerText, out number))
                    {
                        ProjTask.TimeUsed += number;
                    }
                    ProjTask.TaskStatus = true;
                    //bool check = await dynamicsService.UpdateTasks(ProjTask);
                    if (true)
                    {
                        isRunning = false;
                        time = new TimeOnly();
                        SetTime();
                        await Shell.Current.GoToAsync("//Start");
                    }
                    else
                    {
                        await Shell.Current.DisplayAlert("No Update", "sorry", "OK");
                    }
                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
            }
        }

        /// <summary>
        /// is need to update the timer label
        /// </summary>
        private void SetTime()
        {
            TimerText = $"{time.Minute}:{time.Second:00}";
        }
    }
}
