namespace ABMAppFinal.ABMViews;

[QueryProperty(nameof(ItemId), nameof(ItemId))]
public partial class ABMAddVehicle : ContentPage
{
    string imagePath { get; set; }
    string _filename = Path.Combine(FileSystem.AppDataDirectory, "vehicles.txt");
	public ABMAddVehicle()
	{
		InitializeComponent();

		string appDataPath = FileSystem.AppDataDirectory;
		string randomFileName = $"{Path.GetRandomFileName()}.vehicles.txt";

		LoadVehicle(Path.Combine(appDataPath, randomFileName));
	}

    private async void SaveButton_Clicked(object sender, EventArgs e)
    {
		string[] data = new string[7];
		data[0] = ABMModelo.Text;
        data[1] = ABMMarca.Text;
        data[2] = ABMYear.Text;
        data[3] = ABMPlaca.Text;
        data[4] = ABMPrecio.Text;
        data[5] = ABMCiudad.Text;
        data[6] = imagePath;
		if (BindingContext is ABMModels.ABMVehicle vehicle)
			File.WriteAllLines(vehicle.Filename, data);

		await Shell.Current.GoToAsync("..");
    }

	private void LoadVehicle(string filename) 
	{
		ABMModels.ABMVehicle vehicleModel = new ABMModels.ABMVehicle();
		vehicleModel.Filename = filename;

		if (File.Exists(filename))
		{
			vehicleModel.abmModelo = File.ReadAllLines(filename)[0];
			vehicleModel.abmMarca= File.ReadAllLines(filename)[1];
            vehicleModel.abmYear = Int32.Parse(File.ReadAllLines(filename)[2]);
			vehicleModel.abmPlaca= File.ReadAllLines(filename)[3];
			vehicleModel.abmPrecio= Double.Parse(File.ReadAllLines(filename)[4]);
			vehicleModel.abmCiudad= File.ReadAllLines(filename)[5];
            vehicleModel.abmPicture = File.ReadAllLines(filename)[6];
            ABMDeleteButton.IsVisible = true;
		}

		BindingContext = vehicleModel;
	}

	public string ItemId
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

    private async void DeleteButton_Clicked(object sender, EventArgs e)
    {
        if (BindingContext is ABMModels.ABMVehicle vehicle)
        {
            // Delete the file.
            if (File.Exists(vehicle.Filename))
                File.Delete(vehicle.Filename);
        }

        await Shell.Current.GoToAsync("..");
    }
}