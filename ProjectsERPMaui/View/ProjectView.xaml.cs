using ProjectsERPMaui.ViewModel;

namespace ProjectsERPMaui.View;

public partial class ProjectView : ContentPage
{
	public ProjectView(ProjectViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
	}
}