public partial class CA : CheckLabel
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		StartTracking(SaveMonitor.Checks_CA);
	}
}

