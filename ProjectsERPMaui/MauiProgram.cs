using Microsoft.Extensions.Logging;
using ProjectsERPMaui.View;
using ProjectsERPMaui.ViewModel;

namespace ProjectsERPMaui;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder.UseMauiApp<App>().ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		builder.Services.AddSingleton<LoginViewModel>();
        builder.Services.AddSingleton<StartViewModel>();
        builder.Services.AddSingleton<ProjectViewModel>();
        builder.Services.AddSingleton<TaskViewModel>();
		builder.Services.AddSingleton<PomodoroViewModel>();

		builder.Services.AddTransient<LoginView>();
        builder.Services.AddTransient<ProjectView>();
        builder.Services.AddTransient<StartView>();
		builder.Services.AddTransient<TaskView>();
		builder.Services.AddTransient<PomodoroView>();

        return builder.Build();
	}
}
