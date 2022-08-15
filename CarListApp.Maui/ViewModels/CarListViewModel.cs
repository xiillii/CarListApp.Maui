using CarListApp.Maui.Models;
using CarListApp.Maui.Services;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Diagnostics;
using CarListApp.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;

namespace CarListApp.Maui.ViewModels;

public partial class CarListViewModel : BaseViewModel
{
    

    public ObservableCollection<Car> Cars { get; private set; } = new();

    public CarListViewModel()
    {
        Title = "Car List";
        GetCarList().Wait();
    }

    [ObservableProperty]
    private bool _isRefreshing;

    [ObservableProperty]
    private string _make;

    [ObservableProperty]
    private string _model;

    [ObservableProperty]
    private string _vin;

    [RelayCommand]
    private async Task GetCarList()
    {
        if (IsLoading)
        {
            return;    
        }

        try
        {
            IsLoading = true;
            if (Cars.Any())
            {
                Cars.Clear();
            }

            var cars = App.CarService.GetCars();

            foreach (var car in cars)
            {
                Cars.Add(car);
            }
        }
        catch (Exception e)
        {
            Debug.WriteLine($"Unable to get cars: {e.Message}");
            await Shell.Current.DisplayAlert("Error", "Failed to retrieve list of cars.", "OK");
        }
        finally
        {
            IsLoading = false;
            IsRefreshing = false;
        }
    }

    [RelayCommand]
    private async Task GetCarDetails(int id)
    {
        if (id == 0)
        {
            return;
        }

        await Shell.Current.GoToAsync($"{nameof(CarDetailsPage)}?Id={id}", true);
    }

    [RelayCommand]
    private async Task AddCar()
    {
        if (string.IsNullOrEmpty(Make) || string.IsNullOrEmpty(Model) || string.IsNullOrEmpty(Vin))
        {
            await Shell.Current.DisplayAlert("Invalid Data", "Please insert valid data", "Ok");
            return;
        }

        var car = new Car
        {
            Make = Make,
            Model = Model,
            Vin = Vin,
        };

        App.CarService.AddCar(car);
        await Shell.Current.DisplayAlert("Info", App.CarService.StatusMessage, "Ok");
        await GetCarList();
    }

    [RelayCommand]
    private async Task DeleteCar(int id)
    {
        if (id == 0)
        {
            await Shell.Current.DisplayAlert("Invalid record", "Please select on record to delete", "Ok");
            return;
        }
        var result = App.CarService.DeleteCar(id);
        if (result == 0)
        {
            await Shell.Current.DisplayAlert("Failed", "Please insert valid data", "Ok");
        }
        else
        {
            await Shell.Current.DisplayAlert("Deletion Successful", "Record removed successfully", "Ok");
            await GetCarList();
        }
    }

    [RelayCommand]
    private async Task UpdateCar(int id)
    {
        return;
    }
}