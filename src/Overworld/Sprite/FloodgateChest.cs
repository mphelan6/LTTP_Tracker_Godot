public partial class FloodgateChest : CheckSprite
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		StartTracking((int)Check.Name.FLOODGATE_CHEST);
	}
}
