using Godot;
using System;

public partial class Main : Control
{
	
	[Export] private FirstStart _startWindow;
	[Export] private MatchmakerWindow _matchamkerWindow;
	[Export] private OrchestratorWindow _orchestratorWindow;
	[Export] private ConfigurationSerializer _serializer;

	public override void _Ready()
	{
		
		_startWindow.Visible = true;
		_startWindow.OnPathSaved += () => _startWindow.Visible = false;

		_matchamkerWindow.OnSaveToJson += _serializer.SaveChanges;
		_orchestratorWindow.OnSaveToJson += _serializer.SaveChanges;

	}


}
