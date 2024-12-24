using MeijerProject.Models;
using MeijerProject.ViewModels;

namespace MeijerProject.Views;

public partial class ProductListView : ContentPage
{
    private readonly ProductListViewModel _viewModel;
    public ProductListView(ProductListViewModel viewModel)
    {
        _viewModel = viewModel;

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
            var detailView = MauiProgram.Provider?.GetRequiredService<ProductDetailView>();
            if (detailView != null)
            {
                await Shell.Current.Navigation.PushAsync(detailView);
            }
            //await Shell.Current.GoToAsync($"//detail");
        }
    }
}