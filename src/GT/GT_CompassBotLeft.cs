public partial class GT_CompassBotLeft : CheckSprite
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		StartTracking((int)Check.Name.GANONS_TOWER_COMPASS_ROOM_BOTTOM_LEFT);
	}
}
