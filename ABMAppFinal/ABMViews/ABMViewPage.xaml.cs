namespace ABMAppFinal.ABMViews;

[QueryProperty(nameof(ItemId), nameof(ItemId))]
public partial class ABMViewPage : ContentPage
{
    string _filename = Path.Combine(FileSystem.AppDataDirectory, "vehicles.txt");
    public ABMViewPage()
	{
		InitializeComponent();

        string appDataPath = FileSystem.AppDataDirectory;
        string randomFileName = $"{Path.GetRandomFileName()}.vehicles.txt";

        LoadVehicle(Path.Combine(appDataPath, randomFileName));
    }

    private void LoadVehicle(string filename)
    {
        ABMModels.ABMVehicle vehicleModel = new ABMModels.ABMVehicle();
        vehicleModel.Filename = filename;

        if (File.Exists(filename))
        {
            vehicleModel.abmModelo = File.ReadAllLines(filename)[0];
            vehicleModel.abmMarca = File.ReadAllLines(filename)[1];
            vehicleModel.abmYear = Int16.Parse(File.ReadAllLines(filename)[2]);
            vehicleModel.abmPlaca = File.ReadAllLines(filename)[3];
            vehicleModel.abmPrecio = Double.Parse(File.ReadAllLines(filename)[4]);
            vehicleModel.abmCiudad = File.ReadAllLines(filename)[5];
            vehicleModel.abmPicture = File.ReadAllLines(filename)[6];
        }

        BindingContext = vehicleModel;
    }

    public string ItemId
    {
        set { LoadVehicle(value); }
    }
}