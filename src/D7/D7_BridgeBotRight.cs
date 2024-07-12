public partial class D7_BridgeBotRight : CheckSprite
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		StartTracking((int)Check.Name.TURTLE_ROCK_EYE_BRIDGE_BOTTOM_RIGHT);
	}
}
