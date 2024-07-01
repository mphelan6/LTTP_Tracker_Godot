using Godot;

public partial class Map : Sprite2D
{
	// variables for dragging
	private bool isDragging = false;
	private Vector2 startDragPos;
	private Vector2 startMousePos;
	private Vector2 mousePos;
	private MouseButton dragButton;

	// variables for zooming
	protected Vector2 minimumScale = new Vector2(0.2f, 0.2f);
	protected Vector2 maximumScale = new Vector2(2.0f, 2.0f);
	private Vector2 zoomOutScaleFactor = new Vector2(0.9f, 0.9f);
	private Vector2 zoomInScaleFactor = new Vector2(1.1f, 1.1f);

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		// handle dragging
		if (isDragging)
		{
			Vector2 mousePos = GetGlobalMousePosition();
			Vector2 offset = startMousePos - mousePos;
			Position = startDragPos - offset;
		}
	}

	// quick check to see if the input is a mouse
	// button used for the dragging operation
	private bool IsDragButton(MouseButton button)
	{
		if (button.Equals(MouseButton.Left) ||
			button.Equals(MouseButton.Right) ||
			button.Equals(MouseButton.Middle))
		{
			return true;
		}
		return false;
	}

	public override void _Input(InputEvent @event)
	{
		// don't move this window while not visible
		if (!Visible)
		{
			return;
		}

		// get mouse event
		if (@event is InputEventMouseButton eventMouseButton)
		{
			// logic to startup the dragging operation
			if (!isDragging && eventMouseButton.IsPressed() && IsDragButton(eventMouseButton.ButtonIndex))
			{
				isDragging = true;
				startDragPos = Position;
				startMousePos = eventMouseButton.Position;
				dragButton = eventMouseButton.ButtonIndex;
			}

			// logic to stop the dragging operation 
			if (isDragging && eventMouseButton.IsReleased() && (eventMouseButton.ButtonIndex == dragButton))
			{
				isDragging = false;
			}

			// zoom out
			if (eventMouseButton.IsPressed() && eventMouseButton.ButtonIndex.Equals(MouseButton.WheelDown)) {
				Vector2 mouseLocalPositionBefore = GetLocalMousePosition();
				Scale = Scale * zoomOutScaleFactor;
				if (Scale < minimumScale) {
					Scale = minimumScale;
				}
				Vector2 mouseLocalPositionAfter = GetLocalMousePosition();

				// this seems to work well for zooming out
				Position += mouseLocalPositionAfter - mouseLocalPositionBefore;
			}

			// zoom in
			if (eventMouseButton.IsPressed() && eventMouseButton.ButtonIndex.Equals(MouseButton.WheelUp)) {
				Scale = Scale * zoomInScaleFactor;
				if (Scale > maximumScale) {
					Scale = maximumScale;
				}

				// TODO: this zoom in is a mess, but it's livable for now 
				
				// used to determine the mouse distance from center screen
				Vector2 mouseGlobalPositionBefore = GetGlobalMousePosition();

				// determine the center of the screen
				float midpointX = GetViewportRect().Size.X / 2.0f;
				float midpointY = GetViewportRect().Size.Y / 2.0f;

				// calculate mouse distance from center as a vector
				Vector2 offsetFromCenter = new Vector2(mouseGlobalPositionBefore.X - midpointX, mouseGlobalPositionBefore.Y - midpointY);

				// attempt to move the screen towards the mouse
				// this movement should slow based on how much we are zoomed in
				float moveFactor = maximumScale.X - Scale.X; // just grabbing X because this will always be the same as Y

				// clamp to a max value
				if (moveFactor > 0.4f) {
					moveFactor = 0.4f;
				}
				Position -= offsetFromCenter * moveFactor;
			}
		} else if (@event is InputEventKey eventKeyboardKey) {
			// zoom reset
			if (eventKeyboardKey.KeyLabel.Equals(Key.Space)) {
				Position = new Vector2(0f, 0f);
				Scale = new Vector2(1f, 1f);
			}
		}
	}
}
