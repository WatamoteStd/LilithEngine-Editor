using System;

public record struct MatchmakerSettingsStruct(
	int PoolUpscaleTime, 
	int MmrUpscale, 
	int MmrDiapason, 
	bool IsLimited
);
