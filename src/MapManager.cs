using Godot;
using System;

public partial class MapManager : Node
{
	private String[] maps = {
		"LightWorld",
		"DarkWorld"
	};

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

	private void _on_map_select_item_selected (int index) {
		SetVisibleMap(maps[index]);
	}
}
