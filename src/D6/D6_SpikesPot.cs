public partial class D6_SpikesPot : CheckSprite
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		StartTracking((int)Check.Name.MISERY_MIRE_SPIKES_POT_KEY);
	}
}
