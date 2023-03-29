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
        [ObservableProperty]
        public Employee _employee;

        public StartViewModel()
        {
            Employee = new Employee();
        }

    }
}
