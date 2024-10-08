namespace M008;

/// <summary>
/// EnumExtension soll zwei Aufgaben erfüllen
/// - einen EnumTypen empfangen
/// - den gegebenen EnumTypen entpacken, und alle Werte aus dem Enumtypen zurückgeben
/// </summary>
public class EnumExtension : IMarkupExtension
{
	public Type EnumType { get; set; }

	/// <summary>
	/// Gibt den Wert an die GUI weiter
	/// Wird in verschiedenen anderen MarkupExtensions verwendet, um das gesamte Bindingsystem zu ermöglichen
	/// </summary>
	public object ProvideValue(IServiceProvider serviceProvider)
	{
		if (!EnumType.IsEnum)
			throw new ArgumentException("EnumType ist kein Enum Typ");

		return Enum.GetValues(EnumType);
	}
}