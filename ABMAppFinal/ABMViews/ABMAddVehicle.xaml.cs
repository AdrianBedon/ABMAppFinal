using ABMAppFinal.ABMModels;

namespace ABMAppFinal.ABMViews;

[QueryProperty(nameof(ItemId), nameof(ItemId))]
public partial class ABMAddVehicle : ContentPage
{
    ABMVehicle ABMItem = new ABMVehicle();
    string imagePath { get; set; }
	public ABMAddVehicle()
	{
		InitializeComponent();
		LoadVehicle();
	}

    private async void SaveButton_Clicked(object sender, EventArgs e)
    {
		ABMItem.abmModelo = ABMModelo.Text;
        ABMItem.abmMarca = ABMMarca.Text;
        ABMItem.abmYear = Int32.Parse(ABMYear.Text);
        ABMItem.abmPlaca = ABMPlaca.Text;
        ABMItem.abmPrecio = Double.Parse(ABMPrecio.Text);
        ABMItem.abmCiudad = ABMCiudad.Text;
        ABMItem.abmPicture = imagePath;
        ABMItem.abmUserId = App.UserApp.Id;
        ABMItem.abmDate = DateTime.ParseExact(ABMFecha.Text, "dd/MM/yyyy HH:mm:ss", null);
        if (ABMSaveButton.Text == "Editar")
        {
            App.VehiclesRepo.UpdateVehicle(ABMItem);
        }
        else
        {
            App.VehiclesRepo.AddNewVehicle(ABMItem);
        }
        await Shell.Current.GoToAsync("..");
    }

	private void LoadVehicle(int value = -1) 
	{
		if (value > -1)
        {
            ABMItem = App.VehiclesRepo.GetVehicle(value);
            imagePath = ABMItem.abmPicture;
            ABMSaveButton.Text = "Editar";
        }

		BindingContext = ABMItem;
	}

	public int ItemId
	{
		set { LoadVehicle(value); }
	}

    private void OnValueChanged(object sender, ValueChangedEventArgs e)
    {
        ABMYear.Text = ABMStepper.Value.ToString();
    }

    private async void OnAddPhoto_Clicked(object sender, EventArgs e)
    {
        ImageStream.Source = "";
        var result = await MediaPicker.PickPhotoAsync(new MediaPickerOptions
        {
            Title = "Select a Photo"
        });

        if (result.ContentType == "image/png" || result.ContentType == "image/jpeg" ||
            result.ContentType == "image/jpg")
        {
            ImageStream.Source = result.FullPath;
            imagePath = result.FullPath;

        }
        else
            await App.Current.MainPage.DisplayAlert("Error Type Image", "Please choose a new image", "Ok");
    }

    private void ABMYear_Loaded(object sender, EventArgs e)
    {
        if (Int32.Parse(ABMYear.Text) <= ABMStepper.Maximum && Int32.Parse(ABMYear.Text) >= ABMStepper.Minimum)
        {
            ABMStepper.Value = Int32.Parse(ABMYear.Text);
        }
        else
        {
            App.Current.MainPage.DisplayAlert("Value Error", "Please enter a value between 1890 and 2022", "Ok");
        }
    }

    private void ABMYear_Completed(object sender, EventArgs e)
    {
        if (Int32.Parse(ABMYear.Text) <= ABMStepper.Maximum && Int32.Parse(ABMYear.Text) >= ABMStepper.Minimum)
        {
            ABMStepper.Value = Int32.Parse(ABMYear.Text);
        }
        else
        {
            App.Current.MainPage.DisplayAlert("Value Error", "Please enter a value between 1890 and 2022", "Ok");
        }
    }

    private async void CancelButton_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}