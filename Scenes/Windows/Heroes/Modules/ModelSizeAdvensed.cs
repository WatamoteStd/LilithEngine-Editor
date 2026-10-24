using Godot;
using System;

public partial class ModelSizeAdvensed : PanelContainer
{
	
	[Export] private LineEdit _radiusEdit;
	[Export] private LineEdit _heightEdit;

	public bool IsBlocked = true;

	public override void _Ready()
	{
		Block();
	}


	public void Unblock()
	{
		IsBlocked = false;
		_radiusEdit.Editable = true;
		_heightEdit.Editable = true;

	}

	public void Block()
	{
		IsBlocked = true;
		_radiusEdit.Editable = false;
		_heightEdit.Editable = false;
	}

	public void GetFields(ref GeneralStatsStruct data)
	{
		
		if (!float.TryParse(_radiusEdit.Text, out var rad))
		{
			return;
		}
		if (!float.TryParse(_heightEdit.Text, out float hei))
		{
			return;
		}

		data.Radius = rad;
		data.Heigth = hei;

	}

	public void SetValue(float rad, float hei)
	{
		
		_radiusEdit.Text = rad.ToString();
		_heightEdit.Text = hei.ToString();

	}

}
