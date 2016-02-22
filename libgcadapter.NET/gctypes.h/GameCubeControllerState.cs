using System;

namespace libgcadapter.NET
{
	public struct GameCubeControllerState : IEquatable<GameCubeControllerState>
	{
		public GameCubeButton Buttons;
		public GameCubeAxis Stick, CStick, Triggers;

		private static GameCubeControllerState _default = new GameCubeControllerState();

		public static GameCubeControllerState Default
		{
			get
			{
				_default.Reset();
				return _default;
			}
		}

		public GameCubeControllerState(GameCubeButton buttons, GameCubeAxis stick, GameCubeAxis cstick, GameCubeAxis triggers)
		{
			Buttons = buttons;
			Stick = stick;
			CStick = cstick;
			Triggers = triggers;
		}

		public void Reset()
		{
			Buttons = GameCubeButton.None;
			Stick.X = Stick.Y = GameCubeAxis.Center;
			CStick.X = CStick.Y = GameCubeAxis.Center;
			Triggers.X = Triggers.Y = 0;
		}

		public bool Button(GameCubeButton button)
		{
			return (Buttons & button) == button;
		}
			
		public bool Equals(GameCubeControllerState other)
		{
			return Buttons == other.Buttons &&
				Stick == other.Stick &&
				CStick == other.CStick &&
				Triggers == other.Triggers;
		}

		public override bool Equals(object obj)
		{
			return obj.GetType() == typeof(GameCubeControllerState) &&
				Equals((GameCubeControllerState)obj);
		}

		public override int GetHashCode()
		{
			return Buttons.GetHashCode() ^ Stick.GetHashCode() ^ CStick.GetHashCode() ^ Triggers.GetHashCode();
		}

		public static bool operator ==(GameCubeControllerState s1, GameCubeControllerState s2)
		{
			return s1.Equals(s2);
		}

		public static bool operator !=(GameCubeControllerState s1, GameCubeControllerState s2)
		{
			return !s1.Equals(s2);
		}
	}
}

