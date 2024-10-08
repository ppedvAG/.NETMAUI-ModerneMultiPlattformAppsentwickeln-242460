namespace M006;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
		count++;

		if (count == 1)
			CounterBtn.Text = $"Clicked {count} time";
		else
			CounterBtn.Text = $"Clicked {count} times";

		//Wenn eine Resource per Code verändert werden soll, muss DynamicResource verwendet werden
		Resources["Black"] = new Color(123, 234, 213);
	}
}
