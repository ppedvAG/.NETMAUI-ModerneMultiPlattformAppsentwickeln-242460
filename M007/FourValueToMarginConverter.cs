using System.Globalization;

namespace M007;

public class FourValueToMarginConverter : IMultiValueConverter
{
	//Quellen -> Ziel
	public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
	{
		double[] d = new double[values.Length];
		for (int i = 0; i < values.Length; i++)
		{
			d[i] = (double) values[i];
		}

		//double[] d = values.OfType<double>().ToArray();

		return new Thickness(d[0], d[1], d[2], d[3]);
	}

	//Ziel -> Quellen
	public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
	{
		throw new NotImplementedException();
	}
}