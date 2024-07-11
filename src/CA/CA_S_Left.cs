public partial class CA_S_Left : CheckSprite
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		StartTracking((int)Check.Name.SEWERS_SECRET_ROOM_LEFT);
	}
}
