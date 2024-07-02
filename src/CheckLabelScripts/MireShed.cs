public partial class MireShed : CheckLabel
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Check[] toTrack = {
			SaveMonitor.Checks[(int)Check.Name.MIRE_SHED_LEFT],
			SaveMonitor.Checks[(int)Check.Name.MIRE_SHED_RIGHT]
		};

		StartTracking(toTrack);
	}
}

