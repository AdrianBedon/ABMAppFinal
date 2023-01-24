using ABMAppFinal.ABMModels;

namespace ABMAppFinal.ABMViews;

public partial class ABMRegisterUser : ContentPage
{
    ABMUser ABMItemU = new ABMUser();
    string imagePath { get; set; }
    public ABMRegisterUser()
	{
        InitializeComponent();
        LoadData();
	}

    public void LoadData()
    {
        if (App.UserApp != null)
        {
            ABMItemU = App.UserApp;
            imagePath = App.UserApp.abmProfilePicture;
            ABMSvBtnUser.Text = "Edit Profile";
        }
        else
        {
            
            ABMItemU = new ABMUser();
            ABMSvBtnUser.Text = "Registrar Usuario";
        }
        BindingContext = ABMItemU;
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
        ABMItemU.abmNames = ABMNames.Text;
        ABMItemU.abmEmail = ABMEmail.Text;
        ABMItemU.abmUsername = ABMUsername.Text;
        ABMItemU.abmPassword = ABMPassword.Text;
        ABMItemU.abmProfilePicture = imagePath;

        if (ABMSvBtnUser.Text == "Edit Profile")
        {
            App.VehiclesRepo.UpdateUser(ABMItemU);
            App.appHeader.LoadData();

            await App.Current.MainPage.DisplayAlert("User", "User profile updated!", "Ok");

            await Shell.Current.GoToAsync("..");
        }
        else
        {
            App.VehiclesRepo.AddNewUser(ABMItemU);

            await App.Current.MainPage.DisplayAlert("User", "User created!", "Ok");

            await Shell.Current.GoToAsync("..");
        }
    }
}