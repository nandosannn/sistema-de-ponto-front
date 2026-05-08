using sistema_de_ponto_front.Services;

namespace sistema_de_ponto_front.Views;

public partial class LoginPage : ContentPage
{
    private readonly ApiService _apiService;

    public LoginPage()
    {
        InitializeComponent();

        _apiService = new ApiService();
    }

    private async void OnLoginClicked(object sender, EventArgs e)
    {
        try
        {
            MessageLabel.Text = "";

            var cpf = CpfEntry.Text;
            var password = PasswordEntry.Text;

            var auth = await _apiService.Login(cpf, password);

            await SecureStorage.SetAsync(
                "auth_token",
                auth.AccessToken
            );

            await DisplayAlert(
                "Sucesso",
                $"Bem-vindo {auth.User.Name}",
                "OK"
            );
        }
        catch (Exception ex)
        {
            MessageLabel.Text = ex.Message;
        }
    }
}