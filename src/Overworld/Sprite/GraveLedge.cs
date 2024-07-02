public partial class GraveLedge : CheckSprite
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		StartTracking((int)Check.Name.GRAVEYARD_CAVE);
	}
}
