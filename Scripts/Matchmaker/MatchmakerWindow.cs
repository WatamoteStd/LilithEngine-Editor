using Godot;
using System;
using System.IO;
using System.Text.Json;

public partial class MatchmakerWindow : PanelContainer
{

	public event Action<MatchmakerSettingsStruct> OnSaveToJson;
	
	[Export] private Button _saveButton;
	[Export] private LineEdit _poolUpscale;
	[Export] private LineEdit _mmrUpscale;
	[Export] private LineEdit _mmrDiapasone;
	[Export] private CheckBox _limited;

	public override void _Ready()
	{
		_saveButton.Pressed += SaveToJson;
	}

	private void SaveToJson()
	{
		
		int.TryParse(_poolUpscale.Text, out int poolUpscaleTime);
		int.TryParse(_mmrUpscale.Text, out int mmrUpscale);
		int.TryParse(_mmrDiapasone.Text, out int mmrDiapasone);
		bool isLimited = _limited.ButtonPressed;

		var config = new MatchmakerSettingsStruct(poolUpscaleTime, mmrUpscale, mmrDiapasone, isLimited);
		OnSaveToJson?.Invoke(config);

	}


}
