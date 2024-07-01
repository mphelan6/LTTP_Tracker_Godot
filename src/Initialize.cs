using Godot;

public partial class Initialize : Node
{
	// constructor, make sure we startup the monitor immediately
	public Initialize()
	{
		SaveMonitor.StartupSaveMonitor();
	}
}
