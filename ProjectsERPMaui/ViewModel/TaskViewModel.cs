using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectsERPMaui.ViewModel
{
    public partial class TaskViewModel : ObservableObject
    {
        [RelayCommand]
        public async void GoToLoginPage()
        {
            await Shell.Current.GoToAsync(nameof(View.LoginView));
        }
    }
}
