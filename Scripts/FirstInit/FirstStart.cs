using Godot;
using System;

public partial class FirstStart : PanelContainer
{

	public event Action OnPathSaved;

	[Export] private FileDialog _fileDialog;
	[Export] private Button _selectDirectButton;
	private const string SectionName = "Settings";
	private const string SettingsFilePath = "user://settings.cfg";
	private const string WorkspaceKey = "workspace_path";

	public override void _Ready()
	{
		
		_selectDirectButton.Pressed += () => _fileDialog.PopupCentered();

		_fileDialog.DirSelected += OnDirSelected;
		CheckExistingWorkspace();

	}

	private void OnDirSelected(string path)
	{
		GD.Print($"Выбрана папка: {path}");
		var config = new ConfigFile();
		config.SetValue(SectionName, WorkspaceKey, path);
		config.Save(SettingsFilePath);

		Cache.Instance.WorkPath = path;

		LoadEditorMainScene(path);
	}

	private void CheckExistingWorkspace()
	{
		var config = new ConfigFile();
		if(config.Load(SettingsFilePath) == Error.Ok)
		{
			string savedPath = (string)config.GetValue(SectionName, WorkspaceKey, string.Empty);
			if(!string.IsNullOrEmpty(savedPath) && DirAccess.DirExistsAbsolute(savedPath))
			{
				GD.Print($"Найден сохраненный воркспейс: {savedPath}");
				Cache.Instance.WorkPath = savedPath;
				LoadEditorMainScene(savedPath);
			}
		}
	}

	private void LoadEditorMainScene(string workspacePath)
	{
		OnPathSaved?.Invoke();
		Visible = false;
	}

}
