using Godot;
using Godot.Collections;

public partial class CameraControls : Camera2D
{
	// variables for dragging
	private bool isDragging = false;
	private Vector2 cameraStartingDragPos;
	private Vector2 mouseStartingDragPos;
	private Vector2 currentMousePos;
	private MouseButton dragButtonPressed;

	// variables for zooming
	protected Vector2 minimumZoom = new Vector2(0.2f, 0.2f);
	protected Vector2 maximumZoom = new Vector2(2.0f, 2.0f);
	private float zoomOutFactor = 0.9f;
	private float zoomInFactor = 1.1f;

	// array of UI nodes to scale with zoom
	private Array<Node> toScaleWithCamera;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		toScaleWithCamera = GetTree().GetNodesInGroup("ToScaleWithCamera");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		// handle dragging
		if (isDragging)
		{
			Vector2 mousePos = GetLocalMousePosition();
			Vector2 offset = currentMousePos - mousePos;
			Vector2 NewPosition = cameraStartingDragPos + offset;

			// clamp position of camera
			if (NewPosition.X > 2000f) {
				NewPosition.X = 2000f;
			}
			if (NewPosition.X < -2000f) {
				NewPosition.X = -2000f;
			}
			if (NewPosition.Y > 2000f) {
				NewPosition.Y = 2000f;
			}
			if (NewPosition.Y < -2000f) {
				NewPosition.Y = -2000f;
			}

			Position = NewPosition;
		}
	}

	// scale UI element with camera zoom
	private void adjustScaleWithCamera() {
		Vector2 newScale = Vector2.One;
		if (Zoom >= Vector2.One) {
			newScale = Vector2.One;
		} else {
			float newScaleVal = -3.5f * Zoom.X + 4.5f;
			newScale = new Vector2(newScaleVal, newScaleVal);
		}

		foreach (Node toScale in toScaleWithCamera) {
			toScale.Set("scale", newScale);
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
		// get mouse event
		if (@event is InputEventMouseButton eventMouseButton)
		{
			// logic to startup the dragging operation
			if (!isDragging && eventMouseButton.IsPressed() && IsDragButton(eventMouseButton.ButtonIndex))
			{
				isDragging = true;
				cameraStartingDragPos = Position;
				currentMousePos = GetLocalMousePosition();
				dragButtonPressed = eventMouseButton.ButtonIndex;
			}

			// logic to stop the dragging operation 
			if (isDragging && eventMouseButton.IsReleased() && (eventMouseButton.ButtonIndex == dragButtonPressed))
			{
				isDragging = false;
			}

			// zoom out
			if (eventMouseButton.IsPressed() && eventMouseButton.ButtonIndex.Equals(MouseButton.WheelDown)) {
				Zoom = Zoom * zoomOutFactor;
				if (Zoom < minimumZoom) {
					Zoom = minimumZoom;
				}
				adjustScaleWithCamera();
			}

			// zoom in
			if (eventMouseButton.IsPressed() && eventMouseButton.ButtonIndex.Equals(MouseButton.WheelUp)) {
				Zoom = Zoom * zoomInFactor;
				if (Zoom > maximumZoom) {
					Zoom = maximumZoom;
				}
				adjustScaleWithCamera();
			}
		} else if (@event is InputEventKey eventKeyboardKey) {
			// zoom reset
			if (eventKeyboardKey.KeyLabel.Equals(Key.Space)) {
				Position = new Vector2(0f, 0f);
				Zoom = Vector2.One;
				adjustScaleWithCamera();
			}
		}
	}
}
