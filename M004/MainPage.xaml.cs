namespace M004;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
		BackendPicker.ItemsSource = Enumerable.Range(0, 10).ToList();
		LV.ItemsSource = new List<Person>()
		{
			new Person("Max", "Mustermann"),
			new Person("Max", "Muster2")
		};
	}

	private void KlickClicked(object sender, EventArgs e)
	{
		Ausgabefeld.Text = Eingabefeld.Text;
	}

	private void Eingabefeld_TextChanged(object sender, TextChangedEventArgs e)
	{
		Ausgabefeld.Text = Eingabefeld.Text;
	}

	private void SearchBar_SearchButtonPressed(object sender, EventArgs e)
	{

	}

	private void CheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
	{

	}

	private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
	{
		Ausgabefeld.FontSize = (double) e.NewValue;
	}

	private void Stepper_ValueChanged(object sender, ValueChangedEventArgs e)
	{
		StepperValue.Text = e.NewValue.ToString();
	}
}

public class Person
{
	public Person(string vorname, string nachname)
	{
		Vorname = vorname;
		Nachname = nachname;
	}

	public string Vorname { get; set; }

	public string Nachname { get; set; }
}