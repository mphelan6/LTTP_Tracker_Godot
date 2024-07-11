public partial class L2_Compass : CheckSprite
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		StartTracking((int)Check.Name.DESERT_PALACE_COMPASS_CHEST);
	}
}
