using CarListApp.Maui.ViewModels;

namespace CarListApp.Maui;

public partial class MainPage : ContentPage
{
    

	public MainPage(CarListViewModel  model)
	{
		InitializeComponent();
		BindingContext = model;
	}
}

