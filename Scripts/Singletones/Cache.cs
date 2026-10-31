using Godot;
using System;

public partial class Cache : Node
{
	
	public static Cache Instance {get; private set;}
	public string WorkPath;
	public ushort MemoryDropValue {get; set;} = 250;

	public override void _Ready()
	{
		
		if (Instance != null)
		{
			QueueFree();
			return;
		}
		Instance = this;



	}


}
