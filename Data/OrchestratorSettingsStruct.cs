
using System;

public record struct OrchestratorSettingsStruct(
	int PortCount,
	int StartPort,
	bool MemoryLeakDrop
);
