namespace CBriscola2._0;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();
#if ANDROID
		MainPage = new AppShell();
#elif WINDOWS
        MainPage=new AppShellWindows();
#endif
	}
}
