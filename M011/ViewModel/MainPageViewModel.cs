using M011.Commands;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace M011.ViewModel;

/// <summary>
/// MVVM
/// Model-View-ViewModel
/// Strikte Trennung von GUI, Backend/Logik, Daten
/// 
/// Drei Schritte:
/// - Drei Ordner erstellen: Model, View, ViewModel
/// - Bestehende Views (u.a. MainPage.xaml) in den View Ordner verschieben
/// - Für jede View ein ViewModel erstellen
///		- Eine Klasse erstellen, welche [ViewName]ViewModel.cs heißt
///		- Den BindingContext der entsprechenden View auf die neue ViewModel Klasse setzen (siehe .xaml)
///		
/// Jede Backend-Klasse (MainPage.xaml.cs) darf nur den Konstruktor mit InitializeComponent enthalten
/// </summary>
public class MainPageViewModel : INotifyPropertyChanged
{
	private string counterBtnText = "Click me";

	public string CounterBtnText
	{
		get => counterBtnText;
		set
		{
			counterBtnText = value;
			Notify();
		}
	}

	private int count;

	/// <summary>
	/// Probleme:
	/// - Keinen Zugriff auf GUI Elemente möglich
	/// - Keine Events mehr möglich (Lösung: Commands)
	/// 
	/// Command
	/// Logik, welche in einem Objekt abgelegt wird, und auch per Bindings in der GUI eingebunden wird
	/// Commands werden im ViewModel abgelegt und per Binding gebunden
	/// 
	/// Problem mit Commands: Für jedes Event muss eine eigene Klasse angelegt werden -> 100e Commands in großen Projekten
	/// Lösung: Generische Command Klasse, welche ihre Logik per Parameter im Konstruktor bekommt
	/// </summary>
	public CounterClickedCommand CounterClickedCommand { get; set; } = new();

	/// <summary>
	/// Hier wird eine Methode benötigt, welche keinen Rückgabewert hat (void), und einen object Parameter hat
	/// </summary>
	public CustomCommand CounterClickedCommand2 { get; set; }

    public MainPageViewModel()
    {
		CounterClickedCommand2 = new(OnCounterClicked, DisableButton);
	}

	/// <summary>
	/// Wenn auf den Button geklickt wird:
	/// - Das Command wird ausgeführt
	/// - Execute wird ausgeführt
	/// - Execute führt den Methodenzeiger aus
	/// - Der Methodenzeiger zeigt auf die Methode OnCounterClicked
	/// </summary>
	public void OnCounterClicked(object o)
	{
		count++;

		if (count == 1)
			CounterBtnText = $"Clicked {count} time";
		else
			CounterBtnText = $"Clicked {count} times";

		SemanticScreenReader.Announce(CounterBtnText);
	}

	/// <summary>
	/// Wenn count == 10, darf der Button nicht mehr geklickt werden
	/// </summary>
	public bool DisableButton(object o)
	{
		return count != 10;
	}

	#region INotifyPropertyChanged
	public event PropertyChangedEventHandler? PropertyChanged;

	public void Notify([CallerMemberName] string prop = "")
	{
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
	}
	#endregion
}