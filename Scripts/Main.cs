using Godot;
using System;
using System.Collections.Generic;

public partial class Main : Control
{
	
	public enum EngineWindow : byte { Matchmaker, Orchestrator, Heroes};
	public EngineWindow CurrentWindow;
	private bool _isMenuOpen = false;
	[Export] private Console _console;

	[Export] private TextureButton _menuButton;
	[Export] private SelectWindowTab _selectWindowTab;

	[ExportCategory("Work Windows")]
	[Export] private FirstStart _startWindow;
	[Export] private MatchmakerWindow _matchamkerWindow;
	[Export] private OrchestratorWindow _orchestratorWindow;
	[Export] private HeroesWindow _heroesWindow;
	[Export] private ConfigurationSerializer _serializer;


	private Dictionary<EngineWindow, IEngineWindow> _windows = new();


	public override void _Ready()
	{

		CurrentWindow = EngineWindow.Orchestrator;
		
		_startWindow.Visible = true;
		_startWindow.OnPathSaved += () =>
		{
			_startWindow.Visible = false;
			_windows[CurrentWindow].ShowWindow();
		};

		_matchamkerWindow.OnSaveToJson += _serializer.SaveChanges;
		_orchestratorWindow.OnSaveToJson += _serializer.SaveChanges;
		_heroesWindow.OnSaveToJson += _serializer.SaveChanges;


		// WINDOWS =======================
		_windows[EngineWindow.Matchmaker] = _matchamkerWindow;
		_windows[EngineWindow.Orchestrator] = _orchestratorWindow;
		_windows[EngineWindow.Heroes] = _heroesWindow;

		foreach(var pair in _windows)
		{
			pair.Value.HideWindow();
		}


		// WINDOWS SWTICHER
		_menuButton.Pressed += WindowSwitcherAction;
		_selectWindowTab.OnChangeWindow += OpenWindow;

		_selectWindowTab.Visible = false;
		_isMenuOpen = false;

	}

	public override void _UnhandledInput(InputEvent @event)
	{
		
		if(@event.IsActionPressed("ConsoleAction"))
		{
			_console.Visible = !_console.Visible;
		}

	}


	private void WindowSwitcherAction()
	{
		_isMenuOpen = !_isMenuOpen;
		_selectWindowTab.Visible = _isMenuOpen;
	}

	private void OpenWindow(EngineWindow window)
	{
		
		if(window == CurrentWindow)
		{
			return;
		}
		else
		{
			_windows[CurrentWindow].HideWindow();
			_windows[window].ShowWindow();
			CurrentWindow = window;
		}

	}


}
