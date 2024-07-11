public partial class D3_Pinball : CheckSprite
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		StartTracking((int)Check.Name.SKULL_WOODS_PINBALL_ROOM);
	}
}
