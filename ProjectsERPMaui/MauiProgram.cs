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
        builder.Services.AddTransient<StartViewModel>();
        builder.Services.AddTransient<ProjectViewModel>();
        builder.Services.AddTransient<TaskViewModel>();

		builder.Services.AddTransient<LoginView>();
        builder.Services.AddTransient<ProjectView>();
        builder.Services.AddTransient<StartView>();
		builder.Services.AddTransient<TaskView>();

        return builder.Build();
	}
}
