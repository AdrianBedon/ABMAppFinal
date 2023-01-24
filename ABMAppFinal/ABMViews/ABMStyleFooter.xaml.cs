using Microsoft.Maui.Controls.Internals;

namespace ABMAppFinal.ABMViews;

public partial class ABMStyleFooter : StackLayout
{
	public ABMStyleFooter()
	{
		InitializeComponent();
	}

    private async void ABMLgOutLgIn_Clicked(object sender, EventArgs e)
    {
        if (ABMLogOutLogIn.Text == "Iniciar Sesi�n")
        {
            await Shell.Current.GoToAsync($"//{nameof(ABMLogin)}");
        }
        else
        {
            App.UserApp = null;
            App.appHeader.LoadData();
            App.appFooter.LoadData();
            await Shell.Current.GoToAsync($"//{nameof(ABMLogin)}");
        }
    }

    public void LoadData()
    {
        if (App.UserApp != null)
        {
            ABMLogOutLogIn.Text = "Cerrar Sesi�n";
        }
        else
        {
            ABMLogOutLogIn.Text = "Iniciar Sesi�n";
        }
        
    }
}