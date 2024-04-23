using BDF.Utility;
using Microsoft.Extensions.Logging;
using System.Windows.Input;
using TN.DVDCentral.BL.Models;

namespace TN.DVDCentral.Maui;

public partial class NewPage1 : ContentPage
{
    List<Movie> movies;
    //MySettings mySettings;
    string APIAddress;
    private readonly ILogger<NewPage1> _logger;

    public ICommand NavigateCommand { get; private set; }

    public NewPage1()
    {
        InitializeComponent();
        //APIAddress = "https://localhost:7054/api/Vehicle";
        //APIAddress = "https://fvtcdp.azurewebsites.net/api/Vehicle";
        APIAddress = "https://dvdcentralapi-120212964.azurewebsites.net/api/Movie";
        //APIAddress = "https://d0a6-72-135-194-142.ngrok-free.app/api/Vehicle";

        NavigateCommand = new Command<Type>(
            async (Type pageType) =>
            {
                Page page = (Page)Activator.CreateInstance(pageType);
                await Navigation.PushAsync(page);
            });


        BindingContext = this;


    }

    private async void Reload()
    {
        ApiClient apiClient = new ApiClient(APIAddress);
        movies = apiClient.GetList<Movie>("Movie");
        Rebind(0);
    }

    private void Rebind(int index)
    {
        cvVehicles.ItemsSource = null;
        cvVehicles.ItemsSource = movies;
    }

    private void StackLayout_Loaded(object sender, EventArgs e)
    {

    }

    private void ContentPage_Loaded(object sender, EventArgs e)
    {
        Reload();
    }

    //private async void Reload()
    //{
    //    try
    //    {
    //        vehicles = (List<Vehicle>)await VehicleManager.Load();

    //        dgVehicles.ItemsSource = null;
    //        dgVehicles.ItemsSource = vehicles;

    //        dgVehicles.Columns[0].Visibility = Visibility.Hidden;
    //        dgVehicles.Columns[1].Visibility = Visibility.Hidden;
    //        dgVehicles.Columns[2].Visibility = Visibility.Hidden;
    //        dgVehicles.Columns[3].Visibility = Visibility.Hidden;


    //    }
    //    catch (Exception ex)
    //    {

    //        throw ex;
    //    }

    //}
}