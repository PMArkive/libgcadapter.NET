using System;

namespace libgcadapter.NET
{
	public enum GameCubeButton
	{
		None = (1 << 0),
		DPadLeft = (1 << 1),
		DPadRight = (1 << 2),
		DPadDown = (1 << 3),
		DPadUp = (1 << 4),
		Z = (1 << 5),
		R = (1 << 6),
		L = (1 << 7),
		A = (1 << 8),
		B = (1 << 9),
		X = (1 << 10),
		Y = (1 << 11),
		Start = (1 << 12)
	}
}

