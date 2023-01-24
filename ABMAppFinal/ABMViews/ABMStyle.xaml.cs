namespace ABMAppFinal.ABMViews;

public partial class ABMStyle : Grid
{
	public ABMStyle()
	{
		InitializeComponent();
	}

	public void LoadData()
	{
		if (App.UserApp != null)
		{
            ABMUserName.Text = App.UserApp.abmUsername;
            ABMUserImage.Source = App.UserApp.abmProfilePicture;
			ABMProfileUser.Text = "Perfil";
        }
		else
		{
			ABMUserName.Text = "Unknown User";
			ABMUserImage.Source = ImageSource.FromFile("default_user.jpg");
            ABMProfileUser.Text = "Registrarse";
        }
	}

    private async void ABMProfileUser_Clicked(object sender, EventArgs e)
    {
		Shell.Current.FlyoutIsPresented = false;
		await Shell.Current.GoToAsync(nameof(ABMRegisterUser));
    }
}