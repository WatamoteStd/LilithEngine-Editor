using Godot;
using System;
using System.Collections.Generic;

public partial class Main : Control
{
	
	public enum EngineWindow : byte { Matchmaker, Orchestrator };
	public EngineWindow CurrentWindow;
	private bool _isMenuOpen = false;

	[Export] private TextureButton _menuButton;
	[Export] private SelectWindowTab _selectWindowTab;

	[ExportCategory("Work Windows")]
	[Export] private FirstStart _startWindow;
	[Export] private MatchmakerWindow _matchamkerWindow;
	[Export] private OrchestratorWindow _orchestratorWindow;
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

		_windows[EngineWindow.Matchmaker] = _matchamkerWindow;
		_windows[EngineWindow.Orchestrator] = _orchestratorWindow;

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
