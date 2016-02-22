using System;

namespace libgcadapter.NET
{
	public struct GameCubeAxis : IEquatable<GameCubeAxis>
	{
		public const byte Center = 128;

		public bool Centered
		{
			get
			{
				return X == Center && Y == Center;
			}
		}

		public byte X, Y;

		public GameCubeAxis(byte x, byte y)
		{
			X = x;
			Y = y;
		}
			
		public bool Equals(GameCubeAxis other)
		{
			return X == other.X &&
				Y == other.Y;
		}

		public override bool Equals(object obj)
		{
			return obj.GetType() == typeof(GameCubeAxis) &&
				Equals((GameCubeAxis)obj);
		}

		public override int GetHashCode()
		{
			return X.GetHashCode() ^ Y.GetHashCode();
		}

		public static bool operator ==(GameCubeAxis a1, GameCubeAxis a2)
		{
			return a1.Equals(a2);
		}

		public static bool operator !=(GameCubeAxis a1, GameCubeAxis a2)
		{
			return !a1.Equals(a2);
		}
	}
}

