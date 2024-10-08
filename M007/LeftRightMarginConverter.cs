using System.Globalization;

namespace M007;

public class LeftRightMarginConverter : IValueConverter
{
	/// <summary>
	/// Convert
	/// Quelle -> Ziel
	/// Hier Slider -> Button
	/// 
	/// Der value Parameter stell den Wert des Bindings dar
	/// </summary>
	public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
	{
		double m = (double) value;
		return new Thickness(m, 0, m, 0);
	}

	/// <summary>
	/// ConvertBack
	/// Ziel -> Quelle
	/// Hier Button -> Slider (nicht benötigt)
	/// </summary>
	public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
	{
		return new Thickness(0);
	}
}