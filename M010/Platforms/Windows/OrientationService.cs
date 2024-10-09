using Windows.Graphics.Display;

namespace M010.Services;

public partial class OrientationService
{
	public partial Orientation GetOrientation()
	{
		DisplayOrientations o = DisplayInformation.GetForCurrentView().CurrentOrientation;
		return o == DisplayOrientations.Landscape || o == DisplayOrientations.LandscapeFlipped ? Orientation.Landscape : Orientation.Portrait;
	}
}