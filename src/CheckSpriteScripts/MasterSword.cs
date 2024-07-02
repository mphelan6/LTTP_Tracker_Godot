public partial class MasterSword : CheckSprite
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		StartTracking((int)Check.Name.MASTER_SWORD_PEDESTAL);
	}
}
