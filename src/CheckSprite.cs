using Godot;

public partial class CheckSprite : Sprite2D
{
	private CompressedTexture2D collectedTexture     = GD.Load<CompressedTexture2D>("res://png/check_collected.png");
	private CompressedTexture2D notCollectedTexture  = GD.Load<CompressedTexture2D>("res://png/not_collected.png");

	private Check checkToTrack;

	public void StartTracking (int toTrack) {
		checkToTrack = SaveMonitor.Checks[toTrack];
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (checkToTrack.isCollected) {
			this.Texture = collectedTexture;
		} else {
			this.Texture = notCollectedTexture;
		}
	}
}
