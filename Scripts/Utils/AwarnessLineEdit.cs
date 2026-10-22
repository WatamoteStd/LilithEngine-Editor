using Godot;
using System;
using System.Collections.Generic;


public partial class AwarnessLineEdit : HBoxContainer
{
	public event Action OnHintWarn;
	public event Action OnWarningWarn;
	public event Action OnCriticalWarn;


	public enum AwarenessType : byte { Hint, Warning, Critical}

	[Export] private LineEdit _lineEdit;
	[Export] private Label _label;
	[Export] private int _hintShowValue = 10;
	[Export] private int _warningShowValue = 20;
	[Export] private int _criticalShowValue = 30;

	[ExportGroup("Custom Warning Messages")]
	[Export] private string _hintMessage = "Optimal value";
	[Export] private string _warningMessage = "Higher than optimal";
	[Export] private string _criticalMessage = "Might not work as intended";
	public override void _Ready()
	{
		
		_lineEdit.TextChanged += CheckChanges;
		CheckChanges(_lineEdit.Text);

	}

	private void CheckChanges(string text)
	{
		
		if(!int.TryParse(text, out var value))
		{
			_label.Visible = false;
			return;
		}



		if (value >= _criticalShowValue)
		{
			_label.Visible = true;
			_label.SelfModulate = Colors.Red;
			_label.Text = _criticalMessage;

			OnCriticalWarn?.Invoke();
		}
		else if (value >= _warningShowValue)
		{
			_label.Visible = true;
			_label.SelfModulate = Colors.Yellow;
			_label.Text = _warningMessage;

			OnWarningWarn?.Invoke();
		}
		else if (value >= _hintShowValue)
		{
			_label.Visible = true;
			_label.SelfModulate = Colors.Gray;
			_label.Text = _hintMessage;

			OnHintWarn?.Invoke();
		}
		else
		{
			_label.Visible = false;
		}

	}


}
