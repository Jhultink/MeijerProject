using MeijerProject.ViewModels;

namespace MeijerProject.Views;

public partial class ProductDetailView : ContentPage
{
    public ProductDetailView(ProductDetailViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
    }
}