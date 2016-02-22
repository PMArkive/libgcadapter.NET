using System;

namespace libgcadapter.NET
{
	public unsafe class GameCubeController
	{
		public GameCubeAdapter Adapter
		{
			get;
			private set;
		}

		public int Port
		{
			get;
			private set;
		}

		public byte Rumble
		{
			get
			{
				int at = 1;
				at += GameCubeAdapter.Ports * sizeof(GameCubeControllerType);
				at += Port;
				return Adapter._adapter[at];
			}
			set
			{
				libgcadapter.gc_pad_set_rumble(Adapter._adapter, Port, value);
			}
		}

		public GameCubeControllerType Type
		{
			get
			{
				int at = 1;
				at += Port * sizeof(GameCubeControllerType);
				byte[] value = new byte[] { 
					Adapter._adapter[at], 
					Adapter._adapter[at + 1],
					Adapter._adapter[at + 2], 
					Adapter._adapter[at + 3]
				}; 
				return (GameCubeControllerType)BitConverter.ToInt32(value, 0);
			}
		}

		public bool PluggedIn
		{
			get
			{
				return Type != GameCubeControllerType.None;
			}
		}

		public bool SupportsRumble
		{
			get
			{
				return Type == GameCubeControllerType.Wired;
			}
		}

		private GameCubeControllerState _state;

		internal GameCubeController(GameCubeAdapter adapter, int port)
		{
			Adapter = adapter;
			Port = port;
			_state = new GameCubeControllerState();
			_state.Reset();
		}

		public GameCubeControllerState Poll()
		{
			fixed(GameCubeControllerState* fstate = &_state)
			{
				libgcadapter.gc_pad_poll(Adapter._adapter, Port, fstate);
			}
			return _state;
		}
	}
}
