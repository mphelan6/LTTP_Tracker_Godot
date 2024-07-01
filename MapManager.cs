using Godot;
using System;

public partial class MapManager : Node
{
	private void SetVisibleMap(String mapNodeName)
	{
		foreach (Node child in GetChildren()) {
			if (child.Name.Equals(mapNodeName)) {
				child.Set("visible", true);
			} else {
				child.Set("visible", false);
			}
		}
	}

	private void _on_light_world_pressed()
	{
		SetVisibleMap("LightWorld");
	}

	private void _on_dark_world_pressed()
	{
		SetVisibleMap("DarkWorld");
	}
}
