using Swd.TimeManager.GuiMaui.ViewModel;
using Swd.TimeManager.GuiMaui.Model;

namespace Swd.TimeManager.GuiMaui.Views;

public partial class PersonListPage : ContentPage
{
	public PersonListPage()
	{
		InitializeComponent();
        //LoadPersonsAsync();

	}


    protected override void OnAppearing()
    {
        base.OnAppearing();
        LoadPersonsAsync();
    }




    private async void LoadPersonsAsync()
    {
        var viewModel = (PersonListPageViewModel)BindingContext;
        await viewModel.LoadPersonAsync();

        await MainThread.InvokeOnMainThreadAsync(() =>
        {
            BindingContext = null;
            BindingContext = viewModel;
        });
    }



}