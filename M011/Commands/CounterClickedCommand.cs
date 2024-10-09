using System.Windows.Input;

namespace M011.Commands;

public class CounterClickedCommand : ICommand
{
	private int count;

	public event EventHandler? CanExecuteChanged;

	/// <summary>
	/// Execute: Code, welcher beim ausführen des Commands ausgeführt wird
	/// Parameter kann über CommandParameter im Xaml mitgegeben werden
	/// Parameter wird über ein Binding mitgegeben
	/// </summary>
	public void Execute(object? parameter)
	{
		string CounterBtnText = parameter.ToString();

		count++;

		if (count == 1)
			CounterBtnText = $"Clicked {count} time";
		else
			CounterBtnText = $"Clicked {count} times";

		SemanticScreenReader.Announce(CounterBtnText);
	}

	public bool CanExecute(object? parameter)
	{
		return true;
	}
}