using Swd.TimeManager.GuiMaui.ViewModel;


namespace Swd.TimeManager.GuiMaui.Views;


public partial class OverViewPage : ContentPage
{
	public OverViewPage()
	{
		InitializeComponent();
	}



    protected override void OnAppearing()
    {
        base.OnAppearing();
        LoadOverViewDataAsync();
    }


    private async Task LoadOverViewDataAsync()
    {
        var viewModel = (OverViewViewModel)BindingContext;
        await viewModel.LoadOverViewDataAsync();
        //await MainThread.InvokeOnMainThreadAsync(() =>
        //    ((ListView)Content).ItemsSource = viewModel.ProjectList
        //    );
    }

}