public partial class D4_Ambush : CheckSprite
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		StartTracking((int)Check.Name.THIEVES_TOWN_AMBUSH_CHEST);
	}
}
