public partial class L2_TorchKey : CheckSprite
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		StartTracking((int)Check.Name.DESERT_PALACE_TORCH);
	}
}
