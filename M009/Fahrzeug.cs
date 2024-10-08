namespace M009;

public class Fahrzeug
{
	public Fahrzeug(int maxV, string marke)
	{
		MaxV = maxV;
		Marke = marke;
	}

	public int MaxV { get; set; }

	public string Marke { get; set; }
}