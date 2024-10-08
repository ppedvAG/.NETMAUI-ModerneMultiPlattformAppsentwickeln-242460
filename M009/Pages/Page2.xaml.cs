namespace M009.Pages;

//[QueryProperty(nameof(Hallo), "Daten")]
[QueryProperty(nameof(Fahrzeug), "Fzg")]
public partial class Page2 : ContentPage
{
	//private string hallo;

	//public string Hallo { set => hallo = value; }

	private Fahrzeug fzg;

	public Fahrzeug Fahrzeug { set => fzg = value; }

	public Page2()
	{
		InitializeComponent();
	}

	private void Button_Clicked(object sender, EventArgs e)
	{

	}
}