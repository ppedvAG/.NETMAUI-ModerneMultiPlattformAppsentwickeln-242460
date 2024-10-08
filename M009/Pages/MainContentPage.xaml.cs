using System.Text.Json;

namespace M009.Pages;

public partial class MainContentPage : ContentPage
{
	public MainContentPage()
	{
		InitializeComponent();
	}

	private async void OnCounterClicked(object sender, EventArgs e)
	{
		//Navigation-Stack

		//Zu anderer Page navigieren
		//Hier können per Konstruktor Daten mitgegeben werden
		Navigation.PushAsync(new Page2(), true);

		//Daten zurückgeben
		//Task<Page> back = Navigation.PopAsync();
		//Page p = await back;
		//p.Resources["Daten"] = 123;

		//////////////////////////////////////////////////////////////////////////////

		//Zu anderer Page wechseln mittels Routing
		string hallo = "Hallo Welt";
		Fahrzeug f = new Fahrzeug(200, "VW");
		Shell.Current.GoToAsync($"//VW?Fzg={JsonSerializer.Serialize(f)}"); //Daten={hallo}&
	}
}
