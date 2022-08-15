using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using CarListApp.Maui.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace CarListApp.Maui.ViewModels
{

    [QueryProperty(nameof(Id), "Id")]
    public partial class CarDetailsViewModel : BaseViewModel, IQueryAttributable
    {
        [ObservableProperty] 
        private Car _car;

        [ObservableProperty]
        private int _id;

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            Id = Convert.ToInt32(HttpUtility.UrlDecode(query["Id"].ToString()));
            Car = App.CarService.GetCar(Id);
        }
    }
}
