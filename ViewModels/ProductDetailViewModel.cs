using MeijerProject.Models;
using MeijerProject.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeijerProject.ViewModels;

public class ProductDetailViewModel : BaseViewModel
{
    private int _productId;

    private ProductDetail? detail;
    public ProductDetail? Detail
    {
        get => detail;
        set { detail = value; OnPropertyChanged(); }
    }

    private readonly IProductService _productService;

    public ProductDetailViewModel(IProductService productService)
    {
        _productService = productService;
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
}
