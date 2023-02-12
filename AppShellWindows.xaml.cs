namespace TrumpSuitGame;

public partial class AppShellWindows : Shell
{
    public static bool aggiorna = false;

    public AppShellWindows()
    {
        InitializeComponent();
    }

    protected override void OnNavigated(ShellNavigatedEventArgs args)
    {
        string current = args.Current.Location.ToString();
        if (current is "//Main")
            if (aggiorna)
            {
                MainPage.AggiornaOpzioni();
                aggiorna = false;
            }
        base.OnNavigated(args);

    }
}
