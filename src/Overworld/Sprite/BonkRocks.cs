public partial class BonkRocks : CheckSprite
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		StartTracking((int)Check.Name.BONK_ROCK_CAVE);
	}
}
