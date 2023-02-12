namespace CBriscola2._0;

public partial class AppShell : Shell
{
	public static bool aggiorna=false;
	public AppShell()
	{
		InitializeComponent();
	}
    protected override void OnNavigated(ShellNavigatedEventArgs args)
    {
        string current = args.Current.Location.ToString();
        if (current is "//Main")
            if (aggiorna)
            {
                cbriscola.MainPage.AggiornaOpzioni();
                aggiorna = false;
            }
        base.OnNavigated(args);

    }
}
