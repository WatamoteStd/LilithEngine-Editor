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

	public (bool result, float rad, float hei) GetFields()
	{
		
		if (!float.TryParse(_radiusEdit.Text, out var rad))
		{
			return (false, 0, 0);
		}
		if (!float.TryParse(_heightEdit.Text, out float hei))
		{
			return (false, 0, 0);
		}

		return (true, rad, hei);

	}

	public void SetValue(float rad, float hei)
	{
		
		_radiusEdit.Text = rad.ToString();
		_heightEdit.Text = hei.ToString();

	}

}
