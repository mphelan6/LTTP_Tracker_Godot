public partial class SahashralasHut : CheckLabel
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Check[] toTrack = {
			SaveMonitor.Checks[(int)Check.Name.SAHASRAHLA],
			SaveMonitor.Checks[(int)Check.Name.SAHASRAHLAS_HUT_LEFT],
			SaveMonitor.Checks[(int)Check.Name.SAHASRAHLAS_HUT_MIDDLE],
			SaveMonitor.Checks[(int)Check.Name.SAHASRAHLAS_HUT_RIGHT]
		};

		StartTracking(toTrack);
	}
}

