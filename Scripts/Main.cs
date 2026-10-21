using Godot;
using System;

public partial class Main : Control
{
	
	[Export] private FirstStart _startWindow;
	[Export] private MatchmakerWindow _matchamkerWindow;

	public override void _Ready()
	{
		
		_startWindow.Visible = true;
		_startWindow.OnPathSaved += () => _startWindow.Visible = false;

	}


}
