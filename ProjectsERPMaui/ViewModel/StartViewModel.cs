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
        {

            Projects.Add(new Project()
            {
                ProjectName = "Test1",
                ProjectID = 1,
            });
            Projects.Add(new Project()
            {
                ProjectName = "Test2",
                ProjectID = 1,
            });
            Projects.Add(new Project()
            {
                ProjectName = "Test3",
                ProjectID = 1,
            });
            Projects.Add(new Project()
            {
                ProjectName = "Test4",
                ProjectID = 1,
            });

        }
    }
}
