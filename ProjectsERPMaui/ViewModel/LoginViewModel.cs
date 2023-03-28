using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectsERPMaui.Model;
using ProjectsERPMaui.Services;
using System.Diagnostics;

namespace ProjectsERPMaui.ViewModel
{
    public partial class LoginViewModel :ObservableObject
    {
        ObservableCollection<Employee> employees { get; set; } = new ObservableCollection<Employee>();
        ObservableCollection<Project> Projects { get; } = new ObservableCollection<Project>();
        ObservableCollection<Task> Tasks { get; } = new ObservableCollection<Task>();

        [ObservableProperty]
        public string _usernameCheck;

        [ObservableProperty]
        public string _passwordCheck;

        [ObservableProperty]
        public string _messageText;

        [ObservableProperty]
        public Employee _emp;
        public LoginViewModel()
        {
            //Get all Employees from Dynamics
            
            _emp = new Employee()
            {
                EmpID = 1,
                Name = "Hans",
                Lastname = "Petersen",
                Email = "HansPetersen@Mail.com",
                Username = "HP",
                Password = "password",
            };

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
        public async void LoginCheck()
        {
            try
            {
                if (PasswordCheck == Emp.Password && UsernameCheck == Emp.Username)
                {
                    GoToStartPage();
                    MessageText = "";
                }
                else
                {
                    MessageText = "Password or Username wrong";
                }
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
            }
        }

        public async void GoToStartPage()
        {
            await Shell.Current.GoToAsync("//Start");          
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

        }
    }
}
