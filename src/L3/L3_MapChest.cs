public partial class L3_MapChest : CheckSprite
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		StartTracking((int)Check.Name.TOWER_OF_HERA_MAP_CHEST);
	}
}
