public partial class GT_HelmKey : CheckSprite
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		StartTracking((int)Check.Name.GANONS_TOWER_MINI_HELMASAUR_KEY_DROP);
	}
}
