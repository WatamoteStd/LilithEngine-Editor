using Godot;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

public partial class Console : PanelContainer
{   
	
	[Export] private LineEdit _commandLine;
	[Export] private RichTextLabel _history;

	public override void _Ready()
	{
		_commandLine.TextSubmitted += ExecuteCommand;
	}

	private void ExecuteCommand(string data)
	{
		
		if(string.IsNullOrWhiteSpace(data)) return;

		string[] tokens = data.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);

		string command = tokens[0].ToLower();

		string[] args = tokens.Skip(1).ToArray();

		switch(command)
		{
			
			case "start":
				HandleStart(args);
			break;

			case "cls":
				_history.Clear();
			break;

			case "memory_drop_value":
				HandleMemoryDrop(args);
			break;

			default:
				_history.AppendText("\nUnknown Command");
			break;

		}

		_commandLine.Clear();

	}

	private void HandleStart(string[] args)
	{
		
		if(args.Length == 0) return;

		string target = args[0].ToLower();

		bool useNats = args.Contains("-nats");

		if (target == "mm" || target == "matchmaker")
		{
			_history.AppendText("\nStarting matchmaker..");
			StartMatchmaker();
			if(useNats)
			{
				_history.AppendText("\nNATS starting...");
				StartNats();
			}
		}
		else if (target == "nats")
		{
			_history.AppendText("\nNATS starting...");
			StartNats();
		}

	}
	

	private void HandleMemoryDrop(string[] args)
	{
		
		if(args.Length == 0) return;
		if(!ushort.TryParse(args[0], out ushort value))
		{
			_history.AppendText($"\nInvalid syntax. Waiting for: memory_drop_value [value]");
			return;
		}

		Cache.Instance.MemoryDropValue = value;
		_history.AppendText($"\nMemory Drop value changed to: {value}mb !");

	}



	private void StartNats()
	{
		
		var startInfo = new ProcessStartInfo
		{
			FileName = Path.Combine(Cache.Instance.WorkPath, "NATS", "nats-server.exe"),
			UseShellExecute = true,
			CreateNoWindow = false
		};

		Process.Start(startInfo);

	}

	private void StartMatchmaker()
	{
		
		var startInfo = new ProcessStartInfo
		{
			FileName = Path.Combine(Cache.Instance.WorkPath, "Backend", "Moba.Matchmaker", "bin", "Debug", "net10.0", "Moba.Matchmaker.exe"),
			UseShellExecute = true,
			CreateNoWindow = false
		};

		Process.Start(startInfo);

	}

	
}
