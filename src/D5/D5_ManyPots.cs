public partial class D5_ManyPots : CheckSprite
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		StartTracking((int)Check.Name.ICE_PALACE_MANY_POTS_POT_KEY);
	}
}
