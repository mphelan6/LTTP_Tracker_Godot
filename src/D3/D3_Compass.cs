public partial class D3_Compass : CheckSprite
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		StartTracking((int)Check.Name.SKULL_WOODS_COMPASS_CHEST);
	}
}
