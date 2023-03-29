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
using CommunityToolkit.Mvvm.Messaging;
using ProjectsERPMaui.Messages;

namespace ProjectsERPMaui.ViewModel
{
    [QueryProperty(nameof(Employee), nameof(Employee))]
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
        public Employee _employee;
        public LoginViewModel()
        {
            _employee= new Employee();
            dynamicsService = new DynamicsService();
        }

        [RelayCommand]
        public async void LoginCheck()
        {
            try
            {

                Employee = await dynamicsService.GetEmployee(UsernameCheck, PasswordCheck);
                await Shell.Current.DisplayAlert("Employee = ", "lastname " + Employee.LastName + " name " + Employee.FirstName, "ok");
                if (Employee.Boolean)
                {
                    await GoToStartPage();
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

        async Task GoToStartPage()
        {
            await Shell.Current.GoToAsync($"//Start",true,
                new Dictionary<string, object>
                {
                    ["Employee"] = Employee
                });
        }


        //async Task SendEmployee()
        //{
        //    WeakReferenceMessenger.Default.Send(new SendEmployeeInfo(Emp));
        //}

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
