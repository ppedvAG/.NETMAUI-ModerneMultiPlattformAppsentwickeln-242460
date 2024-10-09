using M010.Services;
using M010.Model;
using System.Collections.ObjectModel;
using System.Text.Json;

namespace M010;

public partial class MainPage : ContentPage
{
	int count = 0;

	/// <summary>
	/// DependencyInjection
	/// 
	/// In der Start-Methode (MauiProgram.CreateMauiApp()) werden Services registriert
	/// 
	/// Über Parameter im Konstruktor wird das Objekt empfangen
	/// </summary>
	public MainPage(OrientationService orientationService)
	{
		InitializeComponent();
		orientationService.GetOrientation();

		Connectivity.ConnectivityChanged += Connectivity_ConnectivityChanged;
	}

	private async void Connectivity_ConnectivityChanged(object? sender, ConnectivityChangedEventArgs e)
	{
		if (e.NetworkAccess == NetworkAccess.Internet)
		{
			//Daten zwischenspeichern
			ObservableCollection<Fahrzeug> fahrzeuge = new ObservableCollection<Fahrzeug>
			{
				new Fahrzeug(251, FahrzeugMarke.BMW),
				new Fahrzeug(274, FahrzeugMarke.BMW),
				new Fahrzeug(146, FahrzeugMarke.BMW),
				new Fahrzeug(208, FahrzeugMarke.Audi),
				new Fahrzeug(189, FahrzeugMarke.Audi),
				new Fahrzeug(133, FahrzeugMarke.VW),
				new Fahrzeug(253, FahrzeugMarke.VW),
				new Fahrzeug(304, FahrzeugMarke.BMW),
				new Fahrzeug(151, FahrzeugMarke.VW),
				new Fahrzeug(250, FahrzeugMarke.VW),
				new Fahrzeug(217, FahrzeugMarke.Audi),
				new Fahrzeug(125, FahrzeugMarke.Audi)
			};

			string json = JsonSerializer.Serialize(fahrzeuge);

			Stream file = await FileSystem.OpenAppPackageFileAsync("Data.json");

			StreamWriter sw = new StreamWriter(file);

			sw.WriteLine(json);
		}
	}
}