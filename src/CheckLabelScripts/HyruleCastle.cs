using Godot;
using System;

public partial class HyruleCastle : CheckLabel
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Check[] toTrack = {
			SaveMonitor.Checks[(int)Check.Name.HYRULE_CASTLE_BOOMERANG_CHEST],
			SaveMonitor.Checks[(int)Check.Name.HYRULE_CASTLE_BOOMERANG_GUARD_KEY_DROP],
			SaveMonitor.Checks[(int)Check.Name.HYRULE_CASTLE_MAP_CHEST],
			SaveMonitor.Checks[(int)Check.Name.HYRULE_CASTLE_MAP_GUARD_KEY_DROP],
			SaveMonitor.Checks[(int)Check.Name.HYRULE_CASTLE_ZELDAS_CHEST],
			SaveMonitor.Checks[(int)Check.Name.HYRULE_CASTLE_BIG_KEY_DROP],
			SaveMonitor.Checks[(int)Check.Name.SEWERS_DARK_CROSS],
			SaveMonitor.Checks[(int)Check.Name.SEWERS_KEY_RAT_KEY_DROP],
			SaveMonitor.Checks[(int)Check.Name.SEWERS_SECRET_ROOM_LEFT],
			SaveMonitor.Checks[(int)Check.Name.SEWERS_SECRET_ROOM_MIDDLE],
			SaveMonitor.Checks[(int)Check.Name.SEWERS_SECRET_ROOM_RIGHT],
			SaveMonitor.Checks[(int)Check.Name.SANCTUARY]
		};

		StartTracking(toTrack);
	}
}
