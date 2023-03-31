using ProjectsERPMaui.ViewModel;

namespace ProjectsERPMaui.View;

public partial class PomodoroView : ContentPage
{
	public PomodoroView(PomodoroViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
	}
}