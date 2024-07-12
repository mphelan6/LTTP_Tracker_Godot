public partial class GT_ConveyorStar : CheckSprite
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		StartTracking((int)Check.Name.GANONS_TOWER_CONVEYOR_STAR_PITS_POT_KEY);
	}
}
