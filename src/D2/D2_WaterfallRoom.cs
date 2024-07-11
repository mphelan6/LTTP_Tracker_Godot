public partial class D2_WaterfallRoom : CheckSprite
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		StartTracking((int)Check.Name.SWAMP_PALACE_WATERFALL_ROOM);
	}
}
