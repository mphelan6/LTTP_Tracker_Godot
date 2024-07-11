public partial class CA_BoomerangGuard : CheckSprite
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		StartTracking((int)Check.Name.HYRULE_CASTLE_BOOMERANG_GUARD_KEY_DROP);
	}
}
