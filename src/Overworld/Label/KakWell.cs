public partial class KakWell : CheckLabel
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Check[] toTrack = {
			SaveMonitor.Checks[(int)Check.Name.KAKARIKO_WELL_BOTTOM],
			SaveMonitor.Checks[(int)Check.Name.KAKARIKO_WELL_LEFT],
			SaveMonitor.Checks[(int)Check.Name.KAKARIKO_WELL_MIDDLE],
			SaveMonitor.Checks[(int)Check.Name.KAKARIKO_WELL_RIGHT],
			SaveMonitor.Checks[(int)Check.Name.KAKARIKO_WELL_TOP]
		};

		StartTracking(toTrack);
	}
}

