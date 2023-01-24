using ABMAppFinal.ABMModels;

namespace ABMAppFinal.ABMViews;

public partial class ABMListEdit : ContentPage
{
	public ABMListEdit()
	{
		InitializeComponent();
        LoadVehicles();
    }

    public void LoadVehicles()
    {
        List<ABMVehicle> vehicle = App.VehiclesRepo.GetVehiclesUser(App.UserApp);
        ABMVehicles.ItemsSource = vehicle;
        if (App.UserApp == null)
        {
            Añadir.IsEnabled = false;
        }
        else
        {
            Añadir.IsEnabled = true;
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

            string action = await DisplayActionSheet("Seleccione la acción que desea realizar:", "Cancel", null, "Editar", "Borrar");

            if (action == "Editar")
            {
                await Shell.Current.GoToAsync($"{nameof(ABMAddVehicle)}?{nameof(ABMAddVehicle.ItemId)}={vehicle.Id}");
            }
            else if (action == "Borrar")
            {
                App.VehiclesRepo.DeleteVehicle(vehicle);
                LoadVehicles();
            }
            else
            {
                LoadVehicles();
            }
        }

        ABMVehicles.SelectedItem = null;
    }

    private async void Add_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(ABMAddVehicle));
    }
}