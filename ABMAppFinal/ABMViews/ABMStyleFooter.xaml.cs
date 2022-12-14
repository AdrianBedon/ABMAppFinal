namespace ABMAppFinal.ABMViews;

public partial class ABMStyleFooter : StackLayout
{
	public ABMStyleFooter()
	{
		InitializeComponent();
	}

    private void ABMLogOut_Clicked(object sender, EventArgs e)
    {
        ABMViews.ABMStyle appHeader = new ABMViews.ABMStyle();
        ABMViews.ABMStyleFooter appFooter = new ABMViews.ABMStyleFooter();
        AppShell.Current.FlyoutHeader = appHeader;
        AppShell.Current.FlyoutFooter = appFooter;
    }

    public void SetAvailable()
    {
        ABMLogOut.IsVisible= true;
    }
}