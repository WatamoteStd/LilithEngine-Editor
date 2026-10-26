using Godot;
using System;

public partial class HeroListStats : PanelContainer
{
	
	[ExportCategory("Stats")]
	[Export] private LineEdit _healthLine;
	[Export] private LineEdit _healthRegenLine;
	[Export] private LineEdit _manaLine;
	[Export] private LineEdit _manaRegenLine;
	[Export] private LineEdit _armorLine;
	[Export] private LineEdit _moveSpeedLine;
	[Export] private LineEdit _damageLine;
	[Export] private LineEdit _BASLine;
	[Export] private LineEdit _attackRangeLine;
	[Export] private OptionButton _attackType;


	public void GetFields(ref HeroStruct data)
	{
		
		if(float.TryParse(_healthLine.Text, out var health))
		{
			data.BaseHealth = health;
		}
		else data.BaseHealth = 250;

		if(float.TryParse(_healthRegenLine.Text, out var hpReg))
		{
			data.HealthRegen = hpReg;
		}
		else data.HealthRegen = 1f;

		if(float.TryParse(_manaLine.Text, out var mana))
		{
			data.BaseMana = mana;
		}
		else data.BaseMana = 120f;

		if(float.TryParse(_manaRegenLine.Text, out var manReg))
		{
			data.ManaRegen = manReg;
		}
		else data.ManaRegen = 0.8f;

		if(float.TryParse(_armorLine.Text, out var armor))
		{
			data.Armor = armor;
		}
		else data.Armor = 1f;

		if(float.TryParse(_moveSpeedLine.Text, out var ms))
		{
			data.MoveSpeed = ms;
		}
		else data.MoveSpeed = 2f;
		

		if(float.TryParse(_damageLine.Text, out var dmg))
		{
			data.Damage = dmg;
		}
		else data.Damage = 20f;

		if(float.TryParse(_BASLine.Text, out var bas))
		{
			data.BasicAttackTime = bas;
		}
		else data.BasicAttackTime = 1.75f;

		if(float.TryParse(_attackRangeLine.Text, out var atr))
		{
			data.AttackRange = atr;
		}
		else data.AttackRange = 3f;

		if(_attackType.GetSelectedId() == 0) data.AttackType = 0; // melee
		else data.AttackType = 1; // ranged

	}


}
