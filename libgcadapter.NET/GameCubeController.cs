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
				libgcadapter.gc_adapter_t adapter = Marshal.PtrToStructure<libgcadapter.gc_adapter_t>((IntPtr)Adapter._adapter);
				return adapter.state[Port];
			}
		}

		public byte Rumble
		{
			get
			{
				libgcadapter.gc_adapter_t adapter = Marshal.PtrToStructure<libgcadapter.gc_adapter_t>((IntPtr)Adapter._adapter);
				return adapter.rumble[Port];
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
				libgcadapter.gc_adapter_t adapter = Marshal.PtrToStructure<libgcadapter.gc_adapter_t>((IntPtr)Adapter._adapter);
				return adapter.pad[Port];
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
