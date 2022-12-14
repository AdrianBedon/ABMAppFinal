namespace ABMAppFinal.ABMViews;

public partial class ABMLogin : ContentPage
{
    string appDataPath = FileSystem.AppDataDirectory;
    string _filename = Path.Combine(FileSystem.AppDataDirectory, "users.txt");
    public ABMLogin()
	{
		InitializeComponent();
	}

    private async void ABMLogIn_Clicked(object sender, EventArgs e)
    {
        string randomFileName = ABMUsername.Text + ".users.txt";
        string Filename = Path.Combine(appDataPath, randomFileName);
        if (File.Exists(Filename))
        {
            if (ABMPassword.Text.Equals(File.ReadAllLines(Filename)[2]))
            {
                ABMStyle appHeader = new ABMStyle();
                appHeader.SetData(ABMUsername.Text, File.ReadAllLines(Filename)[3]);
                AppShell.Current.FlyoutHeader = appHeader;
                ABMStyleFooter appFooter = new ABMStyleFooter();
                AppShell.Current.FlyoutFooter = appFooter;
                appFooter.SetAvailable();
                await Shell.Current.GoToAsync("..");
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("User Error", "Username or Password Error", "Ok");
            }
        }
        else
        {
            await App.Current.MainPage.DisplayAlert("User Error", "Username or Password Error", "Ok");
        }
    }
}