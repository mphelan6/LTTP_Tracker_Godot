public partial class L2 : CheckLabel
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		StartTracking(SaveMonitor.Checks_L2);
	}
}

