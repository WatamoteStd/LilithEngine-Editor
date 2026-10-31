using Godot;
using System;
using System.IO;
using System.Text.Json;

public partial class ConfigurationSerializer : Node
{

	public void SaveChanges(MatchmakerSettingsStruct config)
	{
		
		var settings = new JsonSerializerOptions
		{
			WriteIndented = true
		};

		string dir = Path.Combine(Cache.Instance.WorkPath, "bin", "Backend", "configs", "editor");
		Directory.CreateDirectory(dir);

		string filePath = Path.Combine(dir, "matchmaker.json");
		
		var jsonText = JsonSerializer.Serialize(config, settings);
		File.WriteAllText(filePath, jsonText);

		GD.Print($"[ConfigurationSerializer] Matchmaker settings saved.");
	}

	public void SaveChanges(OrchestratorSettingsStruct config)
	{
		
		var settings = new JsonSerializerOptions { WriteIndented = true };

		string dir = Path.Combine(Cache.Instance.WorkPath, "Backend", "configs", "editor");
		Directory.CreateDirectory(dir);

		string filePath = Path.Combine(dir, "orchestrator.json");

		var jsonText = JsonSerializer.Serialize(config, settings);
		File.WriteAllText(filePath, jsonText);

		GD.Print($"[ConfigurationSerializer] Orchestrator settings saved.");

	}

	public void SaveChanges(HeroStruct config)
	{
		
		var settings = new JsonSerializerOptions { WriteIndented = true };

		string dir = Path.Combine(Cache.Instance.WorkPath, "gamedata", "heroes");
		if(!Directory.Exists(dir)) Directory.CreateDirectory(dir);

		string filePath = Path.Combine(dir, $"{config.Name}.json");

		var jsonText = JsonSerializer.Serialize(config, settings);
		File.WriteAllText(filePath, jsonText);

		GD.Print($"[ConfigurationSerializer] Hero saved.");

	}
	
}
