using System.Windows.Input;

namespace M011.Commands;

public class CustomCommand : ICommand
{
	public event EventHandler? CanExecuteChanged;

	private Action<object> execute;

	private Func<object, bool> canExecute;

	/// <summary>
	/// Hier werden über den Konstruktor Methodenzeiger empfangen (Referenzen zu Methoden)
	/// Diese Methodenzeiger werden bei Execute und CanExecute eingesetzt
	/// 
	/// Methodenzeiger in C# werden mit Action oder Func definiert
	/// Action: Methodenzeiger, welcher keinen Rückgabewert hat (void) und bis zu 16 Parameter hat
	/// Func: Methodenzeiger, welcher einen Rückgabewert hat (T) und bis zu 16 Parameter hat
	/// </summary>
	public CustomCommand(Action<object> execute, Func<object, bool> canExecute = null)
	{
		this.execute = execute;
		this.canExecute = canExecute;
	}

	public void Execute(object? parameter)
	{
		execute?.Invoke(parameter); //Invoke: Führe die Methode hinter dem Methodenzeiger aus
	}

	public bool CanExecute(object? parameter)
	{
		if (canExecute == null)
			return true;
		return canExecute.Invoke(parameter);
	}
}