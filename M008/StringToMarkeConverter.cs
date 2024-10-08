using System.Globalization;

namespace M008;

public class StringToMarkeConverter : IValueConverter
{
	//Objekt -> Picker
	//FahrzeugMarke -> String
	public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
	{
		return value.ToString();
	}

	//Picker -> Objekt
	//string -> FahrzeugMarke
	public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
	{
		return Enum.Parse<FahrzeugMarke>(value.ToString());
	}
}