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
            //Get all Employees from Dynamics
            
            //_emp = new Employee()
            //{
            //    EmpID = 1,
            //    Firstname = "Hans",
            //    Lastname = "Petersen",
            //    Boolean = true,
            //};
        }

        [RelayCommand]
        public async void LoginCheck()
        {
            try
            {
                Emp = await dynamicsService.GetEmployee(UsernameCheck,PasswordCheck);

                if (Emp.Boolean)
                {
                    MessagingCenter.Send<LoginViewModel, Employee>(this, MessengerKeys.GetEmpl, Emp);
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
    }
}
