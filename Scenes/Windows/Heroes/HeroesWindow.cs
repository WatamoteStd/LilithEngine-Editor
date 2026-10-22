using Godot;
using System;

public partial class HeroesWindow : PanelContainer, IEngineWindow
{
	
	public void ShowWindow()
	{
		Visible = true;
	}
	public void HideWindow()
	{
		Visible = false;
	}

}
