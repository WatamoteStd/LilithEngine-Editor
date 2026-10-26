using Godot;
using System;

public partial class HeroListGeneral : PanelContainer
{  

	[Export] private Label _frameworkIdLabel;
	[Export] private LineEdit _name;
	
	[ExportCategory("Model Size")]
	[Export] private ModelSizeAdvensed _modelSizeTab;
	[Export] private OptionButton _modelPrefab;

	public override void _Ready()
	{
		
		// FOR MODEL
		_modelPrefab.ItemSelected += ChangeModelAdvanced;

	}

	private void ChangeModelAdvanced(long index)
	{
		
		if(index == 0)
		{
			_modelSizeTab.Unblock();
			return;
		}

		switch(index)
		{
			
			case 0:
				_modelSizeTab.Unblock();
			break;

			case 1: 
				_modelSizeTab.Block();
				_modelSizeTab.SetValue(1.1f, 1.1f);
			break;
			
			case 2:
				_modelSizeTab.Block();
				_modelSizeTab.SetValue(1.5f, 1.5f);
			break;

			case 3:
				_modelSizeTab.Block();
				_modelSizeTab.SetValue(1.75f, 1.75f);
			break;

			case 4:
				_modelSizeTab.Block();
				_modelSizeTab.SetValue(1.95f, 1.95f);
			break;

		}

	}

	public void GetData(ref HeroStruct data)
	{
		
		_modelSizeTab.GetFields(ref data);
		data.Name = _name.Text;

	}

}
