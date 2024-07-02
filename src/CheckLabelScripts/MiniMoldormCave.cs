public partial class MiniMoldormCave : CheckLabel
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Check[] toTrack = {
			SaveMonitor.Checks[(int)Check.Name.MINI_MOLDORM_CAVE_FAR_LEFT],
			SaveMonitor.Checks[(int)Check.Name.MINI_MOLDORM_CAVE_FAR_RIGHT],
			SaveMonitor.Checks[(int)Check.Name.MINI_MOLDORM_CAVE_GENEROUS_GUY],
			SaveMonitor.Checks[(int)Check.Name.MINI_MOLDORM_CAVE_LEFT],
			SaveMonitor.Checks[(int)Check.Name.MINI_MOLDORM_CAVE_RIGHT]
		};

		StartTracking(toTrack);
	}
}

