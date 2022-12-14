namespace ABMAppFinal.ABMViews;

public partial class ABMStyle : Grid
{
	public ABMStyle()
	{
		InitializeComponent();
	}

	public void SetData(string username, string imagePath)
	{
		ABMUserName.Text = username;
		ABMUserImage.Source= imagePath;
	}
}