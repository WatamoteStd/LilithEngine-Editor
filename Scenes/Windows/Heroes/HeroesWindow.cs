using Godot;
using System;
using System.IO;

public partial class HeroesWindow : PanelContainer, IEngineWindow
{

	public event Action<HeroStruct> OnSaveToJson;
	[Export] private HeroListGeneral _generalTab;
	[Export] private HeroListStats _statsTab;
	[Export] private Button _saveChangesButton;

	public override void _Ready()
	{
		
		_saveChangesButton.Pressed += SaveChanges;

	}

	
	public void ShowWindow()
	{
		Visible = true;
	}
	public void HideWindow()
	{
		Visible = false;
	}

	public void SaveChanges()
	{
		HeroStruct general = default;

		_generalTab.GetData(ref general);
		general.FrameworkId = GetNextFrameworkId();
		_statsTab.GetFields(ref general);

		OnSaveToJson?.Invoke(general);

	}

	private ushort GetNextFrameworkId()
	{
		
		var dir = Path.Combine(Cache.Instance.WorkPath, "gamedata", "heroes");

		if (!Directory.Exists(dir))
		{
			Directory.CreateDirectory(dir);
			return 0;
		}

		var files = Directory.GetFiles(dir, "*.json");
		return (ushort)files.Length;

	}



}
