using Godot;
using System;

public partial class CheckLabel : Label
{
	private Check[] checksToTrack;
	private int totalChecks = 0;

	public void StartTracking(Check[] checksToTrack) {
		this.checksToTrack = checksToTrack;
		this.totalChecks = checksToTrack.Length;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		int checksCollected = 0;
		foreach (Check check in checksToTrack) {
			if (check.isCollected) {
				checksCollected++;
			}
		}

		Text = checksCollected+" / "+totalChecks;
		if (checksCollected == totalChecks) {
			this.Set("theme_override_colors/font_color", new Color(0f, 1f, 0f, 1f));
		}
	}
}
