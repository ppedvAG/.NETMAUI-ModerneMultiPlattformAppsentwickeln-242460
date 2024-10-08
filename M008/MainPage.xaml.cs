using System.Collections.ObjectModel;
using System.ComponentModel;

namespace M008;

public partial class MainPage : ContentPage, INotifyPropertyChanged
{
	//Jedes Property muss nun in eine private Variable und ein public Property aufgeteilt werden
	//Im Setter der Properties muss die Notify Methode aufgerufen werden
	private int counter = 5;

	public int Counter
	{
		get => counter;
		set
		{
			counter = value;
			Notify(nameof(Counter));
		}
	}

	public Fahrzeug MeinAuto { get; set; } = new Fahrzeug(300, FahrzeugMarke.BMW);

	public ObservableCollection<Fahrzeug> Fahrzeuge { get; set; } = new ObservableCollection<Fahrzeug>
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

	public DayOfWeek[] Wochentage { get; set; } = Enum.GetValues<DayOfWeek>();

	public MainPage()
	{
		InitializeComponent();
	}

	private void Button_Clicked(object sender, EventArgs e)
	{
		//Keine Änderungen sichtbar, weil MeinAuto nicht Notify verwendet
		MeinAuto = new Fahrzeug(250, FahrzeugMarke.VW);
		Counter++;

		//List hat keine Benachrichtigung -> ObservableCollection
		Fahrzeuge.Add(MeinAuto);
	}

	//////////////////////////////////////////////////////////
	
	//Diesen Code einfach kopieren
	public event PropertyChangedEventHandler PropertyChanged;

	public void Notify(string prop)
	{
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
	}
}