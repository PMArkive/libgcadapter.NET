using System;
using System.Runtime.InteropServices;

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

		public GameCubeControllerState State
		{
			get
			{
				int at = 2;
				at += GameCubeAdapter.Ports * sizeof(GameCubeControllerType);
				at += Port * sizeof(GameCubeControllerState);
				return (GameCubeControllerState)Marshal.PtrToStructure<GameCubeControllerState>((IntPtr)(Adapter._adapter + at));
			}
		}

		public byte Rumble
		{
			get
			{
				int at = 2;
				at += GameCubeAdapter.Ports * sizeof(GameCubeControllerType);
				at += GameCubeAdapter.Ports * sizeof(GameCubeControllerState);
				at += Port;
				return Adapter._adapter[at];
			}
			set
			{
				libgcadapter.gc_adapter_set_rumble(Adapter._adapter, Port, value);
			}
		}

		public GameCubeControllerType Type
		{
			get
			{
				int at = 2;
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
			
		internal GameCubeController(GameCubeAdapter adapter, int port)
		{
			Adapter = adapter;
			Port = port;
		}
	}
}
