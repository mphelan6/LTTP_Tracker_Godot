public partial class SuperbunnyCave : CheckLabel
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Check[] toTrack = {
			SaveMonitor.Checks[(int)Check.Name.SUPERBUNNY_CAVE_BOTTOM],
			SaveMonitor.Checks[(int)Check.Name.SUPERBUNNY_CAVE_TOP]
		};

		StartTracking(toTrack);
	}
}

