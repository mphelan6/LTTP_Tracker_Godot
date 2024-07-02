public partial class HookshotCave : CheckLabel
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Check[] toTrack = {
			SaveMonitor.Checks[(int)Check.Name.HOOKSHOT_CAVE_BOTTOM_LEFT],
			SaveMonitor.Checks[(int)Check.Name.HOOKSHOT_CAVE_BOTTOM_RIGHT],
			SaveMonitor.Checks[(int)Check.Name.HOOKSHOT_CAVE_TOP_LEFT],
			SaveMonitor.Checks[(int)Check.Name.HOOKSHOT_CAVE_TOP_RIGHT]
		};

		StartTracking(toTrack);
	}
}

