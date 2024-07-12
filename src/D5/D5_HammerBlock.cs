public partial class D5_HammerBlock : CheckSprite
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		StartTracking((int)Check.Name.ICE_PALACE_HAMMER_BLOCK_KEY_DROP);
	}
}
