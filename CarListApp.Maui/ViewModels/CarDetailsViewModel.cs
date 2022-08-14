using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarListApp.Maui.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace CarListApp.Maui.ViewModels
{

    [QueryProperty(nameof(Car), "Car")]
    public partial class CarDetailsViewModel : BaseViewModel
    {
        [ObservableProperty] 
        private Car _car;

        
    }
}
