using System.Globalization;

namespace M008;

public class MarkeToImageConverter : IValueConverter
{
	public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture) =>
		value.ToString().ToLower() + ".png";

	public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture) => 
		throw new NotImplementedException();
}