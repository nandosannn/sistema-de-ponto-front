using sistema_de_ponto_front.Views;

namespace sistema_de_ponto_front;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        return new Window(new NavigationPage(new LoginPage()));
    }
}