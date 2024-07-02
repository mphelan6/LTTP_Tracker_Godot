public partial class ParadoxCave : CheckLabel
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Check[] toTrack = {
			SaveMonitor.Checks[(int)Check.Name.PARADOX_CAVE_LOWER_FAR_LEFT],
			SaveMonitor.Checks[(int)Check.Name.PARADOX_CAVE_LOWER_FAR_RIGHT],
			SaveMonitor.Checks[(int)Check.Name.PARADOX_CAVE_LOWER_LEFT],
			SaveMonitor.Checks[(int)Check.Name.PARADOX_CAVE_LOWER_MIDDLE],
			SaveMonitor.Checks[(int)Check.Name.PARADOX_CAVE_LOWER_RIGHT],
			SaveMonitor.Checks[(int)Check.Name.PARADOX_CAVE_UPPER_LEFT],
			SaveMonitor.Checks[(int)Check.Name.PARADOX_CAVE_UPPER_RIGHT]
		};

		StartTracking(toTrack);
	}
}

