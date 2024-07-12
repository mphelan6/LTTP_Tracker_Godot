public partial class GT_DoubleSwitch : CheckSprite
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		StartTracking((int)Check.Name.GANONS_TOWER_DOUBLE_SWITCH_POT_KEY);
	}
}
