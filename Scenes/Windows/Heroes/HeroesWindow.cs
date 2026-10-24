using Godot;
using System;

public partial class HeroesWindow : PanelContainer, IEngineWindow
{
	[Export] private HeroListGeneral _generalTab;
	
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
		GeneralStatsStruct general = default;

		_generalTab.GetData(ref general);

		

	}

}
