public partial class D1_MapChest : CheckSprite
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		StartTracking((int)Check.Name.PALACE_OF_DARKNESS_MAP_CHEST);
	}
}
