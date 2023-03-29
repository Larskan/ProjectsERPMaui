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
        //ObservableCollection<Employee> employees { get; set; } = new ObservableCollection<Employee>();
        //ObservableCollection<Project> Projects { get; } = new ObservableCollection<Project>();
        //ObservableCollection<Task> Tasks { get; } = new ObservableCollection<Task>();

        DynamicsService dynamicsService;

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
            _emp = new Employee();
            dynamicsService = new DynamicsService();
        }

        [RelayCommand]
        public async void LoginCheck()
        {
            try
            {
                Emp = await dynamicsService.GetEmployee(UsernameCheck, PasswordCheck);
                await Shell.Current.DisplayAlert("Employee = ","lastname "+Emp.LastName+" name "+Emp.FirstName, "ok");
                if (Emp.Boolean)
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



        //IConnectivity connectivity;

        //async Task GetProjectsAsync()
        //{

        //    try
        //    {
        //        if (connectivity.NetworkAccess != NetworkAccess.Internet)
        //        {
        //            await Shell.Current.DisplayAlert("No connectivity!",
        //                $"Please check internet and try again.", "OK");
        //            return;
        //        }

        //        var projects = await dynamicsService.GetProject();

        //        if (Projects.Count != 0)
        //            Projects.Clear();

        //        foreach (var project in projects)
        //            Projects.Add(project);

        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.WriteLine($"Unable to get Projects: {ex.Message}");
        //        await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
        //    }
        //    finally
        //    {
        //        //IsBusy = false;
        //        //IsRefreshing = false;
        //    }

        //}
    }
}
