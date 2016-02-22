using System;

namespace libgcadapter.NET
{
	public class GameCubeAdapterException : Exception
	{
		public GameCubeAdapter Adapter;

		public GameCubeAdapterException(string message, GameCubeAdapter adapter) : base(message)
		{
			Adapter = adapter;
		}
	}
}