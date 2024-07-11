public partial class D1_Hallway : CheckSprite
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		StartTracking((int)Check.Name.PALACE_OF_DARKNESS_HARMLESS_HELLWAY);
	}
}
