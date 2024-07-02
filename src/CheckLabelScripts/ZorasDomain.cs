public partial class ZorasDomain : CheckLabel
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Check[] toTrack = {
			SaveMonitor.Checks[(int)Check.Name.ZORAS_LEDGE],
			SaveMonitor.Checks[(int)Check.Name.KING_ZORA]
		};

		StartTracking(toTrack);
	}
}

