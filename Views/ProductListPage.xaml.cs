using MeijerProject.ViewModels;

namespace MeijerProject.Views;

public partial class ProductListView : ContentPage
{
	public ProductListView(ProductListViewModel viewModel)
	{
		InitializeComponent();

        BindingContext = viewModel;
    }
}