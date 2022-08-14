﻿using CarListApp.Maui.Models;
using CarListApp.Maui.Services;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Diagnostics;
using CarListApp.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;

namespace CarListApp.Maui.ViewModels;

public partial class CarListViewModel : BaseViewModel
{
    private readonly CarService _carService;

    public ObservableCollection<Car> Cars { get; private set; } = new();

    public CarListViewModel(CarService carService)
    {
        Title = "Car List";
        _carService = carService;
    }

    [ObservableProperty]
    private bool _isRefreshing;

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

            var cars = _carService.GetCars();

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
    private async Task GetCarDetails(Car car)
    {
        if (car == null)
        {
            return;
        }

        await Shell.Current.GoToAsync(nameof(CarDetailsPage), true, new Dictionary<string, object>()
        {
            { nameof(Car), car }
        });
    }
}