﻿using MeijerProject.Models;
using MeijerProject.Services.Interfaces;
using System.Windows.Input;

namespace MeijerProject.ViewModels;

public class ProductListViewModel : BaseViewModel
{
    private readonly IProductService _productService;

    private IEnumerable<Product> _products = [];
    public IEnumerable<Product> Products
    {
        get => _products;
        set { _products = value; OnPropertyChanged(); }
    }

    public ICommand RefreshCommand { get; }

    public ProductListViewModel(IProductService productService)
    {
        _productService = productService;

        RefreshCommand = new Command(async () => await LoadProducts());
    }

    public async Task OnAppearing()
    {
        if (!Products.Any())
        {
            await LoadProducts();
        }
    }

    private async Task LoadProducts()
    {
        IsLoading = true;

        Products = (await _productService.GetProductsAsync()) ?? [];

        IsLoading = false;
    }
}
