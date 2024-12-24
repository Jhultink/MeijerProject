using MeijerProject.ViewModels;

namespace MeijerProject.Views;

public partial class ProductDetailView : ContentPage
{
    private readonly ProductDetailViewModel _viewModel;


    public ProductDetailView(ProductDetailViewModel viewModel)
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

    public void Init(int productId)
    {
        _viewModel.Init(productId);
    }
}