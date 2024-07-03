public partial class L1_Compass : CheckSprite
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		StartTracking((int)Check.Name.EASTERN_PALACE_COMPASS_CHEST);
	}
}
