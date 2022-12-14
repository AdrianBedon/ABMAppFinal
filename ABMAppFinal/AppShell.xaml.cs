namespace ABMAppFinal;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(ABMViews.ABMAddVehicle), typeof(ABMViews.ABMAddVehicle));
        Routing.RegisterRoute(nameof(ABMViews.ABMViewPage), typeof(ABMViews.ABMViewPage));
        Routing.RegisterRoute(nameof(ABMViews.ABMLogin), typeof(ABMViews.ABMLogin));
        Routing.RegisterRoute(nameof(ABMViews.ABMRegisterUser), typeof(ABMViews.ABMRegisterUser));
    }
}
