namespace ABMAppFinal.ABMViews;

public partial class ABMListEdit : ContentPage
{
	public ABMListEdit()
	{
		InitializeComponent();

        BindingContext = new ABMModels.ABMAllVehicles();
    }

    protected override void OnAppearing()
    {
        ((ABMModels.ABMAllVehicles)BindingContext).LoadVehicles();
    }

    private async void vehiclesCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count != 0)
        {
            var vehicle = (ABMModels.ABMVehicle)e.CurrentSelection[0];

            await Shell.Current.GoToAsync($"{nameof(ABMAddVehicle)}?{nameof(ABMAddVehicle.ItemId)}={vehicle.Filename}");

            vehiclesCollection.SelectedItem = null;
        }
    }

    private async void Add_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(ABMAddVehicle));
    }
}