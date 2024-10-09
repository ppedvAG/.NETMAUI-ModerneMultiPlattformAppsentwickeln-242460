using M014.Models;
using Microsoft.Data.SqlClient;
using System.Collections.ObjectModel;

namespace M014;

/// <summary>
/// Datenbank
/// 
/// Zwei Möglichkeiten mit einer DB zu interagieren: EntityFramework, Basic SQL-Connection
/// 
/// EntityFramework
/// Object-Relational-Mapper (ORM)
/// Für jede Tabelle in der DB wird eine C#-Klasse erzeugt
/// 
/// //////////////////////////////////////////////////////////////////////////
/// 
/// Setup
/// 
/// NuGet:
/// - Microsoft.EntityFrameworkCore
/// - Entsprechenden DB Treiber: Microsoft.EntityFrameworkCore.SqlServer
/// 
/// VS Extension: EF Core Power Tools
/// - Rechtsklick aufs Projekt -> EF Core Power Tools -> Reverse Engineer
/// - Verbindung herstellen
/// - Tabellen/Prozeduren auswählen
/// - Konfigurieren -> OK
/// </summary>
public partial class MainPage : ContentPage
{
	int count = 0;

	public ObservableCollection<Customer> Kunden { get; set; } = new();

	/// <summary>
	/// Jetzt wird die Context Klasse benötigt
	/// 
	/// Context Klasse = DB Zugriff
	/// 
	/// Mit db.[Tabelle] können jetzt die Daten angegriffen werden
	/// Mit Linq kann die Tabelle gefiltert/sortiert/gruppiert werden
	/// </summary>
	public MainPage()
	{
		InitializeComponent();

		NorthwindContext db = new(); //Per DependencyInjection hinzufügen
		foreach (Customer c in db.Customers.Where(e => e.Country == "UK")) //SELECT * FROM Customers WHERE City = 'UK'
			Kunden.Add(c);

		//Neue Kunden hinzufügen
		//db.Customers.Add(...)
		//db.SaveChanges(); //Nicht vergessen

		///////////////////////////////////////////////////////////////////////////////

		//using SqlConnection connection = new SqlConnection("Data Source=WIN10-LK3;Initial Catalog=Northwind;Integrated Security=True;Encrypt=False");
		//connection.Open();

		//using SqlCommand cmd = connection.CreateCommand();
		//cmd.CommandText = "SELECT * FROM Customers";

		//using SqlDataReader reader = cmd.ExecuteReader();
		//reader.Read();

		//List<object[]> rows = [];
		//while (true)
		//{
		//	object[] data = new object[reader.VisibleFieldCount];
		//	reader.GetValues(data); //Schreibe die Werte in data hinein
		//	rows.Add(data);
		//	bool moreRows = reader.Read();

		//	if (!moreRows)
		//		break;
		//}
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
		count++;

		if (count == 1)
			CounterBtn.Text = $"Clicked {count} time";
		else
			CounterBtn.Text = $"Clicked {count} times";

		SemanticScreenReader.Announce(CounterBtn.Text);
	}
}