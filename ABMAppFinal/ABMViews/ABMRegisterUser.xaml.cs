namespace ABMAppFinal.ABMViews;

public partial class ABMRegisterUser : ContentPage
{
    string imagePath { get; set; }
    string appDataPath = FileSystem.AppDataDirectory;
    string _filename = Path.Combine(FileSystem.AppDataDirectory, "users.txt");
    public ABMRegisterUser()
	{
        InitializeComponent();
	}

    private async void ABMImageUser_Clicked(object sender, EventArgs e)
    {
        ImageStreamUser.Source = "";
        var result = await MediaPicker.PickPhotoAsync(new MediaPickerOptions
        {
            Title = "Select a Photo"
        });

        if (result.ContentType == "image/png" || result.ContentType == "image/jpeg" ||
            result.ContentType == "image/jpg")
        {
            ImageStreamUser.Source = result.FullPath;
            imagePath = result.FullPath;

        }
        else
            await App.Current.MainPage.DisplayAlert("Error Type Image", "Please choose a new image", "Ok");
    }

    private async void ABMSvBtnUser_Clicked(object sender, EventArgs e)
    {
        string randomFileName = ABMUsername.Text + ".users.txt";
        string Filename = Path.Combine(appDataPath, randomFileName);
        string[] data = new string[4];
        data[0] = ABMNames.Text;
        data[1] = ABMUsername.Text;
        data[2] = ABMPassword.Text;
        data[3] = imagePath;
        File.WriteAllLines(Filename, data);

        await App.Current.MainPage.DisplayAlert("User", "User created!", "Ok");

        await Shell.Current.GoToAsync("..");
    }
}