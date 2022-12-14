namespace ABMAppFinal.ABMViews;

public partial class ABMMenuUser : ContentPage
{
	public ABMMenuUser()
	{
		InitializeComponent();
	}

    private async void ABMLogin_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(ABMLogin));
    }

    private async void ABMRegister_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(ABMRegisterUser));
    }
}