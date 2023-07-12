﻿using WarframeMauiApp.Services;

namespace WarframeMauiApp;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseMauiCommunityToolkit()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});



        builder.Services.AddTransient<SampleDataService>();

        
        //View和ViewModel
        #region
        builder.Services.AddSingleton<MainViewModel>();
		builder.Services.AddSingleton<MainPage>();

		builder.Services.AddSingleton<LocalizationViewModel>();
		builder.Services.AddSingleton<LocalizationPage>();

		builder.Services.AddTransient<ListDetailDetailViewModel>();
		builder.Services.AddTransient<ListDetailDetailPage>();

		builder.Services.AddSingleton<ListDetailViewModel>();
		builder.Services.AddSingleton<ListDetailPage>();

        #endregion


        builder.Services.AddSingleton<HttpClient>();
        builder.Services.AddSingleton<WorldStateServices>();

        return builder.Build();
	}
}
