using Godot;
using System;

public partial class SecretPassage : CheckLabel
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Check[] toTrack = {
			SaveMonitor.Checks[(int)Check.Name.SECRET_PASSAGE],
			SaveMonitor.Checks[(int)Check.Name.LINKS_UNCLE]
		};

		StartTracking(toTrack);
	}
}
