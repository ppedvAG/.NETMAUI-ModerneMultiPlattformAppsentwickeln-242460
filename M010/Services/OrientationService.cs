namespace M010.Services;

/// <summary>
/// Hier wird eine partielle Klasse angelegt, welche beim Kompilierungsvorgang mit der entsprechenden zweiten partiellen Klasse zusammengebaut wird
/// 
/// Die zweite Klasse ist im jeweiligen Platforms Ordner, und muss eine Implementation haben
/// 
/// WICHTIG: Alle partiellen Klassen in diesem Schema müssen im gleichen Namespace sein
/// </summary>
public partial class OrientationService
{
	public partial Orientation GetOrientation();
}