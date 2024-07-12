public partial class GT_BigChest : CheckSprite
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		StartTracking((int)Check.Name.GANONS_TOWER_BIG_CHEST);
	}
}
