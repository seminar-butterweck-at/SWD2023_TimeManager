using Swd.TimeManager.GuiMaui.ViewModel;

namespace Swd.TimeManager.GuiMaui.Views;

public partial class SearchListPage : ContentPage
{
	public SearchListPage()
	{
		InitializeComponent();
   

    }


    protected override void OnAppearing()
    {
        base.OnAppearing();
		LoadProjectsAsync();
    }


    private async Task LoadProjectsAsync()
	{
		var viewModel = (SearchListViewModel)BindingContext;
		await MainThread.InvokeOnMainThreadAsync(() =>
		{
			this.BindingContext = null;
			this.BindingContext = viewModel;
		});
	}

}