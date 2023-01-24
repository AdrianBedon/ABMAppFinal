using ABMAppFinal.ABMModels;

namespace ABMAppFinal.ABMViews;

public partial class ABMMain : ContentPage
{
	public ABMMain()
	{
		InitializeComponent();
        LoadVehicles();
	}

    public void LoadVehicles()
    {
        List<ABMVehicle> vehicle = App.VehiclesRepo.GetAllVehicles();
        ABMvehicles.ItemsSource = vehicle;
        if (App.UserApp == null)
        {
            Add.IsEnabled = false;
        }
        else
        {
            Add.IsEnabled = true;
        }
    }

    protected override void OnAppearing()
    {
        LoadVehicles();
    }

    private async void vehiclesCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count != 0)
        {
            var vehicle = (ABMModels.ABMVehicle)e.CurrentSelection[0];
                
            await Shell.Current.GoToAsync($"{nameof(ABMViewPage)}?{nameof(ABMViewPage.ItemId)}={vehicle.Id}");

            ABMvehicles.SelectedItem = null;
        }
    }

    private async void Add_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(ABMAddVehicle));
    }
}