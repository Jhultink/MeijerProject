using MeijerProject.Models;
using MeijerProject.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MeijerProject.ViewModels;

public partial class ProductDetailViewModel : BaseViewModel
{
    private int _productId;

    private ProductDetail? detail;
    public ProductDetail? Detail
    {
        get => detail;
        set { detail = value; OnPropertyChanged(); }
    }

    public ICommand ShareCommand { get; }

    private readonly IProductService _productService;
    private readonly IShare _share;

    public ProductDetailViewModel(IProductService productService, IShare share)
    {
        _productService = productService;
        _share = share;

        ShareCommand = new Command(Share);
    }

    public void Init(int productId)
    {
        _productId = productId;
    }

    public async Task OnAppearing()
    {
        IsLoading = true;
        Detail = await _productService.GetProductDetailsAsync(_productId);
        IsLoading = false;
    }

    private async void Share()
    {
        try
        {
            var location = await Geolocation.Default.GetLastKnownLocationAsync() ?? await Geolocation.Default.GetLocationAsync();

            if (location != null)
            {
                var placemarks = await Geocoding.Default.GetPlacemarksAsync(location);
                var city = placemarks.Where(x => x.Locality != null).FirstOrDefault()?.Locality;
                var shareText = $"{Detail?.Title} - {Detail?.Price} from {city} added to list";

                await _share.RequestAsync(shareText);
            }
            else
            {
                await Shell.Current.DisplayAlert("Unknown Location", "Unable to determine location", "OK");
            }
        }
        catch (Exception)
        {
            await Shell.Current.DisplayAlert("Location Error", "Error while trying to retrieve location data", "OK");
        }
    }
}
