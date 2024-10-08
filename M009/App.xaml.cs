namespace M009;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		//MainPage = new TabPage();

		MainPage = new AppShell();
	}
}
