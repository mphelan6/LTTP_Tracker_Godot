public partial class D3_WestLobby : CheckSprite
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		StartTracking((int)Check.Name.SKULL_WOODS_WEST_LOBBY_POT_KEY);
	}
}
