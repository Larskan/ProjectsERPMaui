using ProjectsERPMaui.ViewModel;

namespace ProjectsERPMaui.View;

public partial class LoginView : ContentPage
{
	public LoginView(LoginViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
	}
}