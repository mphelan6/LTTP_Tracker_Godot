using Godot;
using System;

public partial class MapManager : Node
{
	private Node visibleMap;
	private Node visibleFloor;

	public static String[] Maps = {
		"LightWorld",
		"DarkWorld",
		"CA",
		"L1",
		"L2",
		"L3",
		"AG",
		"D1",
		"D2",
		"D3",
		"D4",
		"D5",
		"D6",
		"D7",
		"GT"
	};

	private void SetVisibleMap(String mapNodeName)
	{
		foreach (Node child in GetChildren()) {
			if (child.Name.Equals(mapNodeName)) {
				child.Set("visible", true);
				visibleMap = child;
			} else {
				child.Set("visible", false);
			}
		}
	}

	private void SetVisibleFloor(string floorMapName) {
		foreach (Node child in visibleMap.GetChildren()) {
			if (child.Name.Equals(floorMapName)) {
				child.Set("visible", true);
				visibleFloor = child;
			} else {
				child.Set("visible", false);
			}
		}
	}

	private void _on_map_select_item_selected (int index) {
		SetVisibleMap(Maps[index]);
		switch (MapManager.Maps[index]) {
			case "CA":
				SetVisibleFloor("1");
				break;
			case "L1":
				SetVisibleFloor("1");
				break;
			case "L2":
				SetVisibleFloor("2");
				break;
			case "L3":
				SetVisibleFloor("4");
				break;
			case "AG":
				SetVisibleFloor("5");
				break;
			case "D1":
				SetVisibleFloor("0");
				break;
			case "D2":
				SetVisibleFloor("0");
				break;
			case "D3":
				SetVisibleFloor("0");
				break;
			case "D4":
				SetVisibleFloor("1");
				break;
			case "D5":
				SetVisibleFloor("0");
				break;
			case "D6":
				SetVisibleFloor("0");
				break;
			case "D7":
				SetVisibleFloor("0");
				break;
			case "GT":
				SetVisibleFloor("5");
				break;
			default:
				visibleFloor = null;
				break;
		}
	}

	// assuming the maps under the visible map are numbered nodes
	//  <visible map>
	//      -> 0
	//      -> 1
	//      -> 2
	//
	//   there's almost definitely a better way to do this
	private void _on_floor_select_item_selected(int index) {
		SetVisibleFloor(index.ToString());
	}
}
