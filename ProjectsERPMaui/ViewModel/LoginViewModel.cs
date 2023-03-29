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
        public Employee _employee;
        public LoginViewModel()
        {
<<<<<<< HEAD
            //Get all Employees from Dynamics
            
            //_emp = new Employee()
            //{
            //    EmpID = 1,
            //    Firstname = "Hans",
            //    Lastname = "Petersen",
            //    Boolean = true,
            //};
=======
            Employee= new Employee { EmpID = 1, FirstName = "Peter", LastName = "Karlson", Boolean = true};
            dynamicsService = new DynamicsService();
>>>>>>> 6807885ae19d1dbe1846aa3509d4314567bab109
        }

        [RelayCommand]
        public async void LoginCheck()
        {
            try
            {
<<<<<<< HEAD
                Emp = await dynamicsService.GetEmployee(UsernameCheck,PasswordCheck);

                if (Emp.Boolean)
                {
                    MessagingCenter.Send<LoginViewModel, Employee>(this, MessengerKeys.GetEmpl, Emp);
                    GoToStartPage();
=======

                //Employee = await dynamicsService.GetEmployee(UsernameCheck, PasswordCheck);
                //await Shell.Current.DisplayAlert("Employee = ", "lastname " + Employee.LastName + " name " + Employee.FirstName, "ok");
                if (Employee.Boolean)
                {
                    await GoToStartPage();
>>>>>>> 6807885ae19d1dbe1846aa3509d4314567bab109
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
<<<<<<< HEAD
            await Shell.Current.GoToAsync("//Start");          
=======
            await Shell.Current.GoToAsync($"//Start",
                new Dictionary<string, object>
                {
                    ["Employee"] = Employee
                });
>>>>>>> 6807885ae19d1dbe1846aa3509d4314567bab109
        }
    }
}
