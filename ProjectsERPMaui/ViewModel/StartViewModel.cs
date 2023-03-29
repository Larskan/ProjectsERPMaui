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
    [QueryProperty(nameof(Employee), nameof(Employee))]
    public partial class StartViewModel : ObservableObject
    {
<<<<<<< HEAD
        ObservableCollection<Project> Projects { get; } = new ObservableCollection<Project>();
        ObservableCollection<Task> Tasks { get; } = new ObservableCollection<Task>();

        [ObservableProperty]
        public Employee _emp;

        public StartViewModel() 
=======
        //ObservableCollection<Task> Tasks { get; } = new ObservableCollection<Task>();
        ObservableCollection<Project> Projects { get; set; } = new ObservableCollection<Project>();

        DynamicsService dynamicsService;

        [ObservableProperty]
        public Project _project;

        [ObservableProperty]
        public Employee _employee;

        public StartViewModel()
        {
            Employee = new Employee();
            Testdata();
            dynamicsService = new DynamicsService();
        }

        [RelayCommand]
        public async void GetProjects()
        {
            try
            {
                //Project = await dynamicsService.GetProjects(Empl.EmpID);
                await GoToProjectPage();
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
            }

        }
        async Task GoToProjectPage()
        {
            await Shell.Current.GoToAsync($"//Project",
                new Dictionary<string, object>
                {
                    ["Projects"] = Projects
                });
        }

        private void Testdata()
>>>>>>> 6807885ae19d1dbe1846aa3509d4314567bab109
        {

            Projects.Add(new Project()
            {
                ProjectName = "Test1",
                ProjectID = 1,
                TotalTime = 100,
                RemainingTime = 100,
            });
<<<<<<< HEAD

            Projects.Add(new Project()
            {
                ProjectName = "Test2",
                ProjectID = 2,
                TotalTime = 80,
                RemainingTime = 60,
            });
        }

        DynamicsService dynamicsService;
        IConnectivity connectivity;

        async Task GetProjectsAsync()
        {

            try
            {
                if (connectivity.NetworkAccess != NetworkAccess.Internet)
                {
                    await Shell.Current.DisplayAlert("No connectivity!",
                        $"Please check internet and try again.", "OK");
                    return;
                }

                var projects = await dynamicsService.GetProject();

                if (Projects.Count != 0)
                    Projects.Clear();

                foreach (var project in projects)
                    Projects.Add(project);

            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to get Projects: {ex.Message}");
                await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
            }
            finally
            {
                //IsBusy = false;
                //IsRefreshing = false;
            }
=======
            Projects.Add(new Project()
            {
                ProjectName = "Test2",
                ProjectID = 1,
                TotalTime = 100,
                RemainingTime = 100,
            });
            Projects.Add(new Project()
            {
                ProjectName = "Test3",
                ProjectID = 1,
                TotalTime = 100,
                RemainingTime = 100,
            });
            Projects.Add(new Project()
            {
                ProjectName = "Test4",
                ProjectID = 1,
                TotalTime = 100,
                RemainingTime = 100,
            });
>>>>>>> 6807885ae19d1dbe1846aa3509d4314567bab109

        }
    }
}
