using Godot;
using System;

public partial class OrchestratorWindow : PanelContainer, IEngineWindow
{

	public event Action<OrchestratorSettingsStruct> OnSaveToJson;
	
	[ExportCategory("Main Settings")]
	[Export] private LineEdit _portsCount;
	[Export] private LineEdit _startPort;
	[Export] private CheckBox _memoryLeakDrop;
	[Export] private Button _saveChanges;

	public override void _Ready()
	{
		_saveChanges.Pressed += SaveChanges;
	}

	private void SaveChanges()
	{
		
		int.TryParse(_portsCount.Text, out int count);
		int.TryParse(_startPort.Text, out int startPort);
		
		OrchestratorSettingsStruct settings = new OrchestratorSettingsStruct(count, startPort, _memoryLeakDrop.ToggleMode);
		OnSaveToJson?.Invoke(settings);
	}

	public void ShowWindow()
	{
		Visible = true;
	}
	public void HideWindow()
	{
		Visible = false;
	}


}
