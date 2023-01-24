using ABMAppFinal.ABMModels;

namespace ABMAppFinal.ABMViews;

[QueryProperty(nameof(ItemId), nameof(ItemId))]
public partial class ABMViewPage : ContentPage
{
    ABMVehicle ABMItem = new ABMVehicle();
    public ABMViewPage()
	{
		InitializeComponent();
        LoadVehicle();
    }

    private void LoadVehicle(int value = -1)
    {
        if (value > -1)
        {
            ABMItem = App.VehiclesRepo.GetVehicle(value);
        }

            BindingContext = ABMItem;
    }

    public int ItemId
    {
        set { LoadVehicle(value); }
    }
}