using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace M011.ViewModel;

public partial class MainPageMVVMToolkitViewModel : ObservableObject
{
	/// <summary>
	/// Hier wird das public Property erzeugt
	/// 
	/// public string CounterBtnText
	/// {
	///		get => counterBtnText;
	///		set
	///		{
	///			counterBtnText = value;
	///			Notify();
	///		}
	/// }
	/// </summary>

	[ObservableProperty]
	private string counterBtnText = "Click me";

	private int counter = 0;

	public ObservableCollection<string> Personen { get; set; } = ["Max", "Udo", "Tim"];

	[RelayCommand(CanExecute = nameof(CounterCanExecute))]
	public void CounterClicked(object o)
	{
		counter++;

		if (counter == 1)
			CounterBtnText = $"Clicked {counter} time";
		else
			CounterBtnText = $"Clicked {counter} times";
	}

	public bool CounterCanExecute(object o)
	{
		return counter != 10;
	}
}