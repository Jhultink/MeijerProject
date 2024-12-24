using MeijerProject.Models;
using MeijerProject.Services.Interfaces;
using MeijerProject.ViewModels;

namespace MeijerProject.Views;

public partial class ProductListView : ContentPage
{
    private readonly ProductListViewModel _viewModel;
    private readonly INavigationService _navigationService;

    public ProductListView(ProductListViewModel viewModel, INavigationService navigationService)
    {
        _viewModel = viewModel;
        _navigationService = navigationService;

        InitializeComponent();

        BindingContext = viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _viewModel.OnAppearing();
    }

    private async void ItemTapped(object sender, ItemTappedEventArgs e)
    {
        if (sender is ListView listView)
            listView.SelectedItem = null;

        if (e.Item is Product product)
        {
            await _navigationService.PushAsync<ProductDetailView>(x => x.Init(product.Id));
        }
    }
}