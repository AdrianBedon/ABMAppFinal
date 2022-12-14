using ABMAppFinal.ABMViews;

namespace ABMAppFinal;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}
}
