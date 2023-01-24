using ABMAppFinal.ABMData;
using ABMAppFinal.ABMModels;
using ABMAppFinal.ABMViews;

namespace ABMAppFinal;

public partial class App : Application
{
    public static ABMStyle appHeader = new ABMStyle();
    public static ABMStyleFooter appFooter = new ABMStyleFooter();
    public static ABMUser UserApp;
	public static ABMDatabase VehiclesRepo { get; set; }
	public App(ABMDatabase repo)
	{
		InitializeComponent();

		MainPage = new AppShell();
		VehiclesRepo = repo;
		appFooter.LoadData();
		appHeader.LoadData();
		Shell.Current.FlyoutFooter = appFooter;
		Shell.Current.FlyoutHeader= appHeader;
	}
}
