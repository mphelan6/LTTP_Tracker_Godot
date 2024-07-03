using Godot;
using System;

public partial class FloorSelectBorder : ColorRect
{
	private void _on_map_select_item_selected(int index)
	{
		if (MapManager.Maps[index].Equals("LightWorld") ||
			MapManager.Maps[index].Equals("DarkWorld")) {
				Visible = false;
		} else {
			Visible = true;
		}
	}
}
