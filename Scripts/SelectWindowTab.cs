using Godot;
using System;

public partial class SelectWindowTab : PanelContainer
{


	public event Action<Main.EngineWindow> OnChangeWindow;
	
	[Export] private Button _orchestrator;
	[Export] private Button _matchmaker;
	[Export] private Button _heroes;

	public override void _Ready()
	{
		
		_orchestrator.Pressed += () => OnChangeWindow?.Invoke(Main.EngineWindow.Orchestrator);
		_matchmaker.Pressed += () => OnChangeWindow?.Invoke(Main.EngineWindow.Matchmaker);
		_heroes.Pressed += () => OnChangeWindow?.Invoke(Main.EngineWindow.Heroes);

	}


}
