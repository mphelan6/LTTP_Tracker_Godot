public partial class SpiralCave : CheckSprite
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		StartTracking((int)Check.Name.SPIRAL_CAVE);
	}
}
