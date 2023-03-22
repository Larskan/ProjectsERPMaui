using ProjectsERPMaui.ViewModel;

namespace ProjectsERPMaui.View;

public partial class TaskView : ContentPage
{
	public TaskView(TaskViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
	}
}