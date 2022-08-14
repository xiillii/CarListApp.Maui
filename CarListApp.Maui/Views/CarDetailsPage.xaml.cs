using CarListApp.Maui.ViewModels;

namespace CarListApp.Maui.Views;

public partial class CarDetailsPage : ContentPage
{
	public CarDetailsPage(CarDetailsViewModel model)
	{
		InitializeComponent();

		BindingContext = model;
	}

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
		// do fanciness
        base.OnNavigatedTo(args);
    }
}