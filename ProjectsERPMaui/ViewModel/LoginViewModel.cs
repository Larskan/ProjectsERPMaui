using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectsERPMaui.Model;

namespace ProjectsERPMaui.ViewModel
{
    public partial class LoginViewModel :ObservableObject
    {
        ObservableCollection<Employee> employees { get; set; } = new ObservableCollection<Employee>();

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
            await Shell.Current.GoToAsync(nameof(View.StartView));
        }
    }
}
