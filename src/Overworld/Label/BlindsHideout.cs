public partial class BlindsHideout : CheckLabel
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Check[] toTrack = {
			SaveMonitor.Checks[(int)Check.Name.BLINDS_HIDEOUT_FAR_LEFT],
			SaveMonitor.Checks[(int)Check.Name.BLINDS_HIDEOUT_FAR_RIGHT],
			SaveMonitor.Checks[(int)Check.Name.BLINDS_HIDEOUT_LEFT],
			SaveMonitor.Checks[(int)Check.Name.BLINDS_HIDEOUT_RIGHT],
			SaveMonitor.Checks[(int)Check.Name.BLINDS_HIDEOUT_TOP]
		};

		StartTracking(toTrack);
	}
}

