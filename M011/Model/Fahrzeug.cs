using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace M011.Model;

public class Fahrzeug : INotifyPropertyChanged
{
	private int maxV;

	public int MaxV
	{
		get => maxV;
		set
		{
			maxV = value;
			Notify();
		}
	}

	private FahrzeugMarke marke;

	public FahrzeugMarke Marke
	{
		get => marke;
		set
		{
			marke = value;
			Notify();
		}
	}

	public Fahrzeug(int maxV, FahrzeugMarke marke)
	{
		this.maxV = maxV;
		this.marke = marke;
	}

	public override string ToString()
	{
		return $"[MaxV = {MaxV}, Marke = {Marke}]";
	}

	////////////////////////////////////////////////////////////////

	public event PropertyChangedEventHandler? PropertyChanged;

	public void Notify([CallerMemberName] string prop = "")
	{
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
	}
}