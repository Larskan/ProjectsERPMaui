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
    public partial class LoginViewModel :ObservableObject
    {
        DynamicsService dynamicsService;

        [ObservableProperty]
        public string _usernameCheck;

        [ObservableProperty]
        public string _passwordCheck;

        [ObservableProperty]
        public string _messageText;

        [ObservableProperty]
        public Employee _empl;
        public LoginViewModel()
        {
            Empl= new Employee { EmpID = 1, FirstName = "Peter", LastName = "Karlson", Boolean = true};
            dynamicsService = new DynamicsService();
        }

        [RelayCommand]
        public async void LoginCheck()
        {
            try
            {

                //Employee = await dynamicsService.GetEmployee(UsernameCheck, PasswordCheck);
                //await Shell.Current.DisplayAlert("Employee = ", "lastname " + Employee.LastName + " name " + Employee.FirstName, "ok");
                if (Empl.Boolean)
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
            await Shell.Current.GoToAsync($"//Start",
                new Dictionary<string, object>
                {
                    ["Empl"] = Empl
                });
        }
    }
}
