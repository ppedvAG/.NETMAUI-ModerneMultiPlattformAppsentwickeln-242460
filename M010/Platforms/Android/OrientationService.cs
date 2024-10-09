using Android.Content;
using Android.Runtime;
using Android.Views;

namespace M010.Services;

public partial class OrientationService
{
	public partial Orientation GetOrientation()
	{
		IWindowManager windowManager = 
			Android.App.Application.Context
			.GetSystemService(Context.WindowService)
			.JavaCast<IWindowManager>();
		SurfaceOrientation o = windowManager.DefaultDisplay.Rotation;
		return o == SurfaceOrientation.Rotation0 || o == SurfaceOrientation.Rotation180 ? Orientation.Portrait : Orientation.Landscape;
	}
}