using ProjectsERPMaui.ViewModel;

namespace ProjectsERPMaui.View;

public partial class StartView : ContentPage
{
	public StartView(StartViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
	}
}