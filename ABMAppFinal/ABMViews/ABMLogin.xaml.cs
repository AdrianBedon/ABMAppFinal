using ABMAppFinal.ABMModels;

namespace ABMAppFinal.ABMViews;

public partial class ABMLogin : ContentPage
{
    public ABMLogin()
	{
		InitializeComponent();
	}

    private async void ABMLogIn_Clicked(object sender, EventArgs e)
    {
        ABMUser userLogin = App.VehiclesRepo.GetUser(ABMUsername.Text);
        
        if (ABMPassword.Text.Equals(userLogin.abmPassword))
        {
            App.UserApp = userLogin;
            App.appHeader.LoadData();
            App.appFooter.LoadData();
            await Shell.Current.GoToAsync($"//{nameof(ABMMain)}");
        }
        else
        {
            await App.Current.MainPage.DisplayAlert("User Error", "Username or Password Error", "Ok");
        }
    }

    private async void ABMRegister_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(ABMRegisterUser));
    }

    private async void ABMContinue_Clicked(object sender, EventArgs e)
    {
        App.UserApp = null;
        App.appHeader.LoadData();
        App.appFooter.LoadData();
        await Shell.Current.GoToAsync($"//{nameof(ABMMain)}");
    }
}