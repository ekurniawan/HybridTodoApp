namespace HybridTodoApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Native UI", "This is from Native MAUI Button", "OK");
        }
    }
}
