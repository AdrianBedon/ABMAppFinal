using ABMAppFinal.ABMData;
using ABMAppFinal.ABMViews;

namespace ABMAppFinal;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		string dbPath = ABMFileAccessHelper.GetLocalFilePath("vehiclesApp.db3");
		builder.Services.AddSingleton<ABMDatabase>(s => ActivatorUtilities.CreateInstance<ABMDatabase>(s, dbPath));
        return builder.Build();
	}
}
