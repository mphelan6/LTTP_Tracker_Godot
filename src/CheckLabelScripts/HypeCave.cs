public partial class HypeCave : CheckLabel
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Check[] toTrack = {
			SaveMonitor.Checks[(int)Check.Name.HYPE_CAVE_BOTTOM],
			SaveMonitor.Checks[(int)Check.Name.HYPE_CAVE_GENEROUS_GUY],
			SaveMonitor.Checks[(int)Check.Name.HYPE_CAVE_MIDDLE_LEFT],
			SaveMonitor.Checks[(int)Check.Name.HYPE_CAVE_MIDDLE_RIGHT],
			SaveMonitor.Checks[(int)Check.Name.HYPE_CAVE_TOP]
		};

		StartTracking(toTrack);
	}
}

