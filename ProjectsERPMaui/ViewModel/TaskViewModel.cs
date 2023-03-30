using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProjectsERPMaui.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectsERPMaui.ViewModel
{
    [QueryProperty(nameof(Project), nameof(Project))]
    public partial class TaskViewModel : ObservableObject
    {
        ObservableCollection<Task> tasksList = new ObservableCollection<Task>();

        [ObservableProperty]
        public Project _project;

        public TaskViewModel()
        {
            _project = new Project();
        }

        [RelayCommand]
        public async void GoToLoginPage()
        {
            await Shell.Current.GoToAsync(nameof(View.LoginView));
        }
    }
}
