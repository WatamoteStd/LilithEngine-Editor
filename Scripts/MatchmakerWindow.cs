using Godot;
using System;
using System.IO;
using System.Text.Json;

public partial class MatchmakerWindow : PanelContainer
{
	
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

		var config = new
		{
			pool_upscale_time = poolUpscaleTime,
			mmr_upscale = mmrUpscale,
			mmr_diapasone = mmrDiapasone,
			limited = isLimited
		};

		string dirPath = Path.Combine(Cache.Instance.WorkPath, "Backend", "configs");
		Directory.CreateDirectory(dirPath);

		string filePath = Path.Combine(dirPath, "matchmaker.json");
		
		var options = new JsonSerializerOptions { WriteIndented = true };
		string jsonString = JsonSerializer.Serialize(config, options);

		File.WriteAllText(filePath, jsonString);
		GD.Print($"[Matchmaker] Config saved to: {filePath}");


	}


}
