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
    [QueryProperty(nameof(Empl), nameof(Empl))]
    public partial class StartViewModel : ObservableObject
    {
<<<<<<< HEAD
        ObservableCollection<Project> Projects { get; set; } = new ObservableCollection<Project>();
=======
        //ObservableCollection<Task> Tasks { get; } = new ObservableCollection<Task>();
        ObservableCollection<Project> ProjList { get; set; } = new ObservableCollection<Project>();

        [ObservableProperty]
        List<Project> _projectsList;
>>>>>>> cb653e410809fdb6e5a8d975266ae94fb3440d55

        DynamicsService dynamicsService;

        [ObservableProperty]
        public Project _project;

        [ObservableProperty]
        public Employee _empl;

        public StartViewModel()
        {
            Empl = new Employee();
<<<<<<< HEAD
            Testdata();
=======
>>>>>>> cb653e410809fdb6e5a8d975266ae94fb3440d55
            dynamicsService = new DynamicsService();
            ProjectsList = new List<Project>();
            Testdata();
        }

        [RelayCommand]
        public async void GetProjects()
        {
            try
            {
                //ProjectsList = await dynamicsService.GetProjects(Employee.EmpID);
                ProjList = new ObservableCollection<Project>(ProjectsList);
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
                    ["ProjList"] = ProjList
                });
        }

        private void Testdata()
        {

            ProjectsList.Add(new Project()
            {
                ProjectName = "Test1",
                ProjectID = 1,
                TaskList = new List<ProjectTask> { new ProjectTask() { TaskName = "Task Test", PlanTime = 50, TimeUsed = 10, Description = "Hallo user", ProjectID = 1, TaskID = 1} },
            });
<<<<<<< HEAD
            Projects.Add(new Project()
=======
            ProjectsList.Add(new Project()
>>>>>>> cb653e410809fdb6e5a8d975266ae94fb3440d55
            {
                ProjectName = "Test2",
                ProjectID = 1,
            });
            ProjectsList.Add(new Project()
            {
                ProjectName = "Test3",
                ProjectID = 1,
            });
            ProjectsList.Add(new Project()
            {
                ProjectName = "Test4",
                ProjectID = 1,
            });
<<<<<<< HEAD
=======

>>>>>>> cb653e410809fdb6e5a8d975266ae94fb3440d55
        }
    }
}
