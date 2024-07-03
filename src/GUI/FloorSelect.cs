using Godot;

public partial class FloorSelect : OptionButton
{
	private void _on_map_select_item_selected(int index)
	{
		switch (MapManager.Maps[index]) {
			case "CA":
				Clear();
				AddItem("2F", 0);
				AddItem("1F", 1);
				AddItem("B1", 2);
				AddItem("B2", 3);
				AddItem("B3", 4);
				Select(1);
				break;
			case "L1":
				Clear();
				AddItem("2F", 0);
				AddItem("1F", 1);
				AddItem("B1", 2);
				Select(1);
				break;
			case "L2":
				Clear();
				AddItem("2F", 0);
				AddItem("1F", 1);
				AddItem("B1", 2);
				Select(2);
				break;
			case "L3":
				Clear();
				AddItem("6F", 0);
				AddItem("5F", 1);
				AddItem("4F", 2);
				AddItem("3F", 3);
				AddItem("2F", 4);
				AddItem("1F", 5);
				AddItem("B1", 6);
				Select(4);
				break;
			case "AG":
				Clear();
				AddItem("7F", 0);
				AddItem("6F", 1);
				AddItem("5F", 2);
				AddItem("4F", 3);
				AddItem("3F", 4);
				AddItem("2F", 5);
				Select(5);
				break;
			case "D1":
				Clear();
				AddItem("1F", 0);
				AddItem("B1", 1);
				Select(0);
				break;
			case "D2":
				Clear();
				AddItem("1F", 0);
				AddItem("B1", 1);
				AddItem("B2", 2);
				Select(0);
				break;
			case "D3":
				Clear();
				AddItem("B1", 0);
				AddItem("B2", 1);
				Select(0);
				break;
			case "D4":
				Clear();
				AddItem("1F", 0);
				AddItem("B1", 1);
				AddItem("B2", 2);
				Select(1);
				break;
			case "D5":
				Clear();
				AddItem("1F", 0);
				AddItem("B1", 1);
				AddItem("B2", 2);
				AddItem("B3", 3);
				AddItem("B4", 4);
				AddItem("B5", 5);
				AddItem("B6", 6);
				AddItem("B7", 7);
				Select(0);
				break;
			case "D6":
				Clear();
				AddItem("1F", 0);
				AddItem("B1", 1);
				AddItem("B2", 2);
				Select(0);
				break;
			case "D7":
				Clear();
				AddItem("1F", 0);
				AddItem("B1", 1);
				AddItem("B2", 2);
				AddItem("B3", 3);
				Select(0);
				break;
			case "GT":
				Clear();
				AddItem("7F", 0);
				AddItem("6F", 1);
				AddItem("5F", 2);
				AddItem("4F", 3);
				AddItem("3F", 4);
				AddItem("2F", 5);
				AddItem("1F", 6);
				AddItem("B1", 7);
				Select(5);
				break;
			default:
				break;
		}
	}
}
