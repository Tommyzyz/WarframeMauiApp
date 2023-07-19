namespace WarframeMauiApp.Views;

public partial class MessionPage : ContentPage
{
	public MessionPage( MessionViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
	}
}