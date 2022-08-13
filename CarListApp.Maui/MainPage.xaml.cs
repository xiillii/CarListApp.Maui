using CarListApp.Maui.ViewModels;

namespace CarListApp.Maui;

public partial class MainPage : ContentPage
{
    
	int count = 0;

	public MainPage(CarListViewModel  model)
	{
		InitializeComponent();
		BindingContext = model;
	}

    private void OnCounterClicked(object sender, EventArgs e)
    {
        throw new NotImplementedException();
    }
}

