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

    public ProductDetailViewModel(IProductService productService)
    {
        _productService = productService;

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
        var location = await Geolocation.Default.GetLocationAsync();

        if (location != null)
        {
            var placemarks = await Geocoding.Default.GetPlacemarksAsync(location);
            var city = placemarks.Where(x => x.Locality != null).FirstOrDefault()?.Locality;
        }
    }
}
