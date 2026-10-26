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

	public void GetFields(ref HeroStruct data)
	{
		float basicRad = 1.0f;
		float basicHei = 1.0f;
		
		if (float.TryParse(_radiusEdit.Text, out basicRad))
		if (float.TryParse(_heightEdit.Text, out basicHei))

		data.Radius = basicRad;
		data.Height = basicHei;

	}

	public void SetValue(float rad, float hei)
	{
		
		_radiusEdit.Text = rad.ToString();
		_heightEdit.Text = hei.ToString();

	}

}
