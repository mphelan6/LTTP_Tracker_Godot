public partial class AG_DarkMaze : CheckSprite
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		StartTracking((int)Check.Name.CASTLE_TOWER_DARK_MAZE);
	}
}
