public partial class D3_GibdoKey : CheckSprite
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		StartTracking((int)Check.Name.SKULL_WOODS_SPIKE_CORNER_KEY_DROP);
	}
}
