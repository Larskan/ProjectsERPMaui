namespace ProjectsERPMaui;
using ProjectsERPMaui.View;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute(nameof(LoginView),typeof(LoginView));
		//Routing.RegisterRoute(nameof(StartView),typeof(StartView));
		//Routing.RegisterRoute(nameof(ProjectView),typeof(ProjectView));
		//Routing.RegisterRoute(nameof(TaskView),typeof(TaskView));
	}
}
