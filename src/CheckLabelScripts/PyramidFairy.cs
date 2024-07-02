public partial class PyramidFairy : CheckLabel
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Check[] toTrack = {
			SaveMonitor.Checks[(int)Check.Name.PYRAMID_FAIRY_LEFT],
			SaveMonitor.Checks[(int)Check.Name.PYRAMID_FAIRY_RIGHT]
		};

		StartTracking(toTrack);
	}
}

