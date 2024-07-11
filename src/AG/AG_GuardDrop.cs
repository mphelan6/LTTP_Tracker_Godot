public partial class AG_GuardDrop : CheckSprite
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		StartTracking((int)Check.Name.CASTLE_TOWER_CIRCLE_OF_POTS_KEY_DROP);
	}
}
