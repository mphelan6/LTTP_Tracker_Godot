public partial class WaterfallFairy : CheckLabel
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Check[] toTrack = {
			SaveMonitor.Checks[(int)Check.Name.WATERFALL_FAIRY_LEFT],
			SaveMonitor.Checks[(int)Check.Name.WATERFALL_FAIRY_RIGHT]
		};

		StartTracking(toTrack);
	}
}

